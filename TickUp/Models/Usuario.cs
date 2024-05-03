using MySql.Data.MySqlClient;

namespace TickUp.Models
{
    public class Usuario
    {

        static string conexao = "Server=localhost;Database=tickup;User id=root;Password=2005";
        private string email, cpf, nome, telefone, senha;
        private int idade;

        public Usuario(string email, string cpf, string nome, string telefone, string senha, int idade)
        {
            this.email = email;
            this.cpf = cpf;
            this.nome = nome;
            this.telefone = telefone;
            this.senha = senha;
            this.idade = idade;
        }

        public string Email { get => email; set => email = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Idade { get => idade; set => idade = value; }


        public string InserirUSuario()
        {
            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO usuarios VALUES(@email, @cpf, @idade, @nome, @telefone, @senha)", con);
                qry.Parameters.AddWithValue("@email", email);
                qry.Parameters.AddWithValue("@cpf", cpf);
                qry.Parameters.AddWithValue("@idade", idade);
                qry.Parameters.AddWithValue("@nome", nome);
                qry.Parameters.AddWithValue("@telefone", telefone);
                qry.Parameters.AddWithValue("@senha", senha);
                qry.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return "Erro: " + ex.InnerException;
            }

            return "Usuario inserido com sucesso!";
        }
    }
}
