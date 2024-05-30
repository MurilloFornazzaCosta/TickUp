using MySql.Data.MySqlClient;

namespace TickUp.Models
{
    public class Ingresso : Evento
    {
        // Outros membros da classe

        Evento evento = new Evento();

        public Ingresso(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string idEvento, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, double valorIngresso) : base(assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, idEvento, horarioInicio, horarioTermino, cpf, email, dataInicio, dataTermino, capacidade, bytesImagem, nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade, valorIngresso)
        {
        }
        public Ingresso()
        {

        }
        public string IngressoComprado(string idEvento, string idIngresso)
        {
            string mensagem = "Comprado com sucesso";

            try
            {
                double valorIngresso;
                string email, cpf;

                // Criação da conexão com o banco de dados
                using (MySqlConnection con = FabricaConexao.getConexao("casaGustavo"))
                {
                    con.Open();

                    // Consulta para obter o valor do ingresso do evento
                    MySqlCommand qryDadosEvento = new MySqlCommand("SELECT ValorIngresso, Email, CPF FROM Evento WHERE idEvento = @idEvento", con);
                    qryDadosEvento.Parameters.AddWithValue("@idEvento", idEvento);

                    // Executa a consulta e obtém o valor do ingresso
                    using (MySqlDataReader reader = qryDadosEvento.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            valorIngresso = Convert.ToDouble(reader["ValorIngresso"]);
                            email = reader["Email"].ToString();
                            cpf = reader["CPF"].ToString();
                        }
                        else
                        {
                            throw new Exception("Evento não encontrado");
                        }
                    }

                        // Prepara a query SQL para inserir o ingresso no banco de dados
                        MySqlCommand qry = new MySqlCommand("INSERT INTO Ingresso (idIngresso, valor, idEvento, cpf, email) VALUES (@idIngresso, @valor, @idEvento, @cpf, @email)", con);
                    qry.Parameters.AddWithValue("@idIngresso", idIngresso);
                    qry.Parameters.AddWithValue("@valor", valorIngresso);
                    qry.Parameters.AddWithValue("@idEvento", idEvento);
                    qry.Parameters.AddWithValue("@cpf", cpf);
                    qry.Parameters.AddWithValue("@email", email);

                    // Executa a query
                    qry.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                mensagem = $"Erro ao comprar o ingresso: {ex.Message}";
            }

            return mensagem;
        }

    }
}

