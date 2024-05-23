using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.IO;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Diagnostics;

namespace TickUp.Models
{
    public class Evento
    {

        private string assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, horarioInicio, horarioTermino, cpf, email;
        private DateOnly dataInicio, dataTermino;
        private int capacidade;
        private byte[] bytesImagem;

        private string nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade;

        private double valorIngresso;

        public string AssuntoEvento { get => assuntoEvento; set => assuntoEvento = value; }
        public string CategoriaEvento { get => categoriaEvento; set => categoriaEvento = value; }
        public string NomeEvento { get => nomeEvento; set => nomeEvento = value; }
        public string EmailContato { get => emailContato; set => emailContato = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public DateOnly DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateOnly DataTermino { get => dataTermino; set => dataTermino = value; }
        public string HorarioInicio { get => horarioInicio; set => horarioInicio = value; }
        public string HorarioTermino { get => horarioTermino; set => horarioTermino = value; }
        public int Capacidade { get => capacidade; set => capacidade = value; }
        public byte[] BytesImagem { get => bytesImagem; set => bytesImagem = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Email { get => email; set => email = value; }


        public string NomeLocal { get => nomeLocal; set => nomeLocal = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cidade { get => cidade; set => cidade = value; }

        public double ValorIngresso { get => valorIngresso; set => valorIngresso = value; }


        public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.cpf = cpf;
            this.email = email;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.capacidade = capacidade;
            this.bytesImagem = bytesImagem;
            this.nomeLocal = nomeLocal;
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.estado = estado;
            this.cidade = cidade;
        }

        public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, double valorIngresso)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.cpf = cpf;
            this.email = email;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.capacidade = capacidade;
            this.bytesImagem = bytesImagem;
            this.nomeLocal = nomeLocal;
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.estado = estado;
            this.cidade = cidade;
            this.valorIngresso = valorIngresso;
        }

        public Evento(byte[] bytesImagem)
        {
            this.bytesImagem = bytesImagem;
        }

        public string Inserir()
        {

            MySqlConnection con = FabricaConexao.getConexao("ConexaoPadrao");
            try
            {
                
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO Evento (dataInicio, horarioInicio, categoriaEvento, nomeEvento, emailContato, observacoes, assuntoEvento, imagem, horarioTermino, dataTermino, capacidade, cpf, email, numero, rua, bairro, nomeLocal, cidade, estado, cep, complemento) VALUES (@dataInicio, @horarioInicio, @categoriaEvento, @nomeEvento, @emailContato, @observacoes, @assuntoEvento, @imagem, @horarioTermino, @dataTermino, @capacidade, @cpf, @email, @numero, @rua, @bairro, @nomeLocal, @cidade, @estado, @cep, @complemento)", con);
                qry.Parameters.AddWithValue("@assuntoEvento", assuntoEvento);
                qry.Parameters.AddWithValue("@categoriaEvento", categoriaEvento);
                qry.Parameters.AddWithValue("@nomeEvento", nomeEvento);
                qry.Parameters.AddWithValue("@emailContato", emailContato);
                qry.Parameters.AddWithValue("@observacoes", observacoes);
                qry.Parameters.AddWithValue("@dataInicio", dataInicio.ToString("yyyy-MM-dd"));
                qry.Parameters.AddWithValue("@dataTermino", dataTermino.ToString("yyyy-MM-dd"));
                qry.Parameters.AddWithValue("@horarioInicio", horarioInicio);
                qry.Parameters.AddWithValue("@horarioTermino", horarioTermino);
                qry.Parameters.AddWithValue("@capacidade", capacidade);
                qry.Parameters.AddWithValue("@cpf", cpf); // Se não tiver o cpf, adicione como NULL no insert
                qry.Parameters.AddWithValue("@email", email); // Se não tiver o email, adicione como NULL no insert
                qry.Parameters.AddWithValue("@numero", numero);
                qry.Parameters.AddWithValue("@rua", rua);
                qry.Parameters.AddWithValue("@bairro", bairro);
                qry.Parameters.AddWithValue("@nomeLocal", nomeLocal);
                qry.Parameters.AddWithValue("@cidade", cidade);
                qry.Parameters.AddWithValue("@estado", estado);
                qry.Parameters.AddWithValue("@cep", cep);
                qry.Parameters.AddWithValue("@complemento", complemento);
                qry.Parameters.AddWithValue("@imagem", bytesImagem);
                qry.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                return "Erro: " + ex.InnerException;
            }

            return "Inserido com sucesso!";


        }

        public static List<Evento> ListarImgEventos()
        {
            List<Evento> eventos = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("ConexaoPadrao");
            try
            {
                con.Open();                
                MySqlCommand qry = new MySqlCommand(
                    "SELECT * FROM Evento", con);
                MySqlDataReader reader = qry.ExecuteReader();
                reader.Read();
                while (reader.Read())
                {

                    string assunto = reader["assuntoEvento"].ToString();
                    string categoria = reader["categoriaEvento"].ToString();
                    string nome = reader["nomeEvento"].ToString();
                    string emailContato = reader["emailContato"].ToString();
                    string observacoes = reader["observacoes"].ToString();
                    string horarioInicio = reader["horarioInicio"].ToString();
                    string horarioTermino = reader["horarioTermino"].ToString();
                    string cpf = reader["cpf"].ToString();
                    string email = reader["email"].ToString();
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
                con.Close();

            }
            catch(Exception ex)
            {

                return eventos;

            }

            return eventos;

        }


    }
}
