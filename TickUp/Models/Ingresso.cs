using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Http;

namespace TickUp.Models
{
    public class Ingresso : Evento
    {

        Evento evento = new Evento();

        public Ingresso(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string idEvento, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, double valorIngresso) : base(assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, idEvento, horarioInicio, horarioTermino, cpf, email, dataInicio, dataTermino, capacidade, bytesImagem, nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade, valorIngresso)
        {
        }
        public Ingresso()
        {

        }
        

        public string IngressoComprado(string idEvento, string idIngresso, int capacidade, HttpContext httpContext)
        {
            string mensagem = "Comprado com sucesso";

            try
            {
                double valorIngresso;
                string email;

                // Recupera o objeto Usuario da sessão
                string usuarioJson = httpContext.Session.GetString("user");

                if (usuarioJson == null)
                {
                    throw new Exception("Usuário não está logado");
                }

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);

                email = usuario.EmailUser;
               

                using (MySqlConnection con = FabricaConexao.getConexao("ConexaoPadrao"))
                {
                    con.Open();

                    MySqlCommand qryDadosEvento = new MySqlCommand("select ValorIngresso FROM evento WHERE idEvento = @idEvento", con);
                    qryDadosEvento.Parameters.AddWithValue("@idEvento", idEvento); 

                    using (MySqlDataReader reader = qryDadosEvento.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valorIngresso = Convert.ToDouble(reader["ValorIngresso"]);
                        }
                        else
                        {
                            throw new Exception("Evento não encontrado");
                        }
                    }

                    MySqlCommand qry = new MySqlCommand("insert INTO ingresso (idIngresso, valor, idEvento, email) VALUES (@idIngresso, @valor, @idEvento, @email)", con);
                    qry.Parameters.AddWithValue("@idIngresso", idIngresso);
                    qry.Parameters.AddWithValue("@valor", valorIngresso);
                    qry.Parameters.AddWithValue("@idEvento", idEvento);
                    qry.Parameters.AddWithValue("@email", email);

                    qry.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                mensagem = $"Erro ao comprar o ingresso: {ex.Message}";
            }

            return mensagem;
        }
        public List<Evento> ListarIngressos(HttpContext httpContext)
        {
            string email;
            // Obtém o objeto Usuario da sessão
            string usuarioJson = httpContext.Session.GetString("user");

            if (usuarioJson == null)
            {
                throw new Exception("Objeto Usuario não encontrado na sessão.");
            }

            // Desserializa o objeto Usuario
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson);

            // Obtém o email do objeto Usuario
            email = usuario.EmailUser;

            var eventos = new List<Evento>();

            using (MySqlConnection con = FabricaConexao.getConexao("ConexaoPadrao"))
            {
                con.Open();

                var query = @"SELECT evento.*, ingresso.*
              FROM ingresso 
              JOIN evento ON ingresso.idEvento = evento.idEvento 
              WHERE ingresso.email = @email"; ;

                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            string assunto = reader["assuntoEvento"].ToString();
                            string categoria = reader["categoriaEvento"].ToString();
                            string nome = reader["nomeEvento"].ToString();
                            string emailContato = reader["emailContato"].ToString();
                            string observacoes = reader["observacoes"].ToString();
                            string idevento = reader["idEvento"].ToString();
                            string horarioInicio = reader["horarioInicio"].ToString();
                            string horarioTermino = reader["horarioTermino"].ToString();
                            string cpf = reader["cpf"].ToString();
                            DateOnly dataInicio = DateOnly.Parse(reader["dataInicio"].ToString());
                            DateOnly dataTermino = DateOnly.Parse(reader["dataTermino"].ToString());
                            int capacidade = (int)reader["capacidade"];
                            byte[] byteImagem = (byte[])reader["imagem"];
                            string nomeLocal = reader["nomeLocal"].ToString();
                            string cep = reader["cep"].ToString();
                            string rua = reader["rua"].ToString();
                            string numero = reader["numero"].ToString();
                            string complemento = reader["complemento"].ToString();
                            string bairro = reader["bairro"].ToString();
                            string estado = reader["estado"].ToString();
                            string cidade = reader["cidade"].ToString();

                            Evento evento = new Evento(
                                  assunto,
                                  categoria,
                                  nome,
                                  emailContato,
                                  observacoes,
                                  idevento,
                                  horarioInicio,
                                  horarioTermino,
                                  cpf,
                                  email,
                                  dataInicio,
                                  dataTermino,
                                  capacidade,
                                  byteImagem,
                                  nomeLocal,
                                  cep,
                                  rua,
                                  numero,
                                  complemento,
                                  bairro,
                                  estado,
                                  cidade
                              );


                            eventos.Add(evento);
                        }
                    }
                }
            }

            return eventos;
        }



    }





}


