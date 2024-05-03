using MySql.Data.MySqlClient;

namespace TickUp.Models
{
    public class Usuario
    {

        private string emailUser, cpfUser, nomeUser, telefoneUser, senhaUser;
        private int idadeUser;


        public string EmailUser { get => emailUser; set => emailUser = value; }
        public string CpfUser { get => cpfUser; set => cpfUser = value; }
        public string NomeUser { get => nomeUser; set => nomeUser = value; }
        public string TelefoneUser { get => telefoneUser; set => telefoneUser = value; }
        public string SenhaUser { get => senhaUser; set => senhaUser = value; }
        public int IdadeUser { get => idadeUser; set => idadeUser = value; }

        public Usuario(string emailUser, string cpfUser, string nomeUser, string telefoneUser, string senhaUser, int idadeUser)
        {
            this.emailUser = emailUser;
            this.cpfUser = cpfUser;
            this.nomeUser = nomeUser;
            this.telefoneUser = telefoneUser;
            this.senhaUser = senhaUser;
            this.idadeUser = idadeUser;

        }

        public string InserirUsuario()
        {
            MySqlConnection con = FabricaConexao.getConexao("casaGustavo");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO usuarios VALUES(@email, @cpf, @nome, @telefone, @senha, @idade)", con);
                qry.Parameters.AddWithValue("@email", emailUser);
                qry.Parameters.AddWithValue("@cpf", cpfUser);
                qry.Parameters.AddWithValue("@idade", idadeUser);
                qry.Parameters.AddWithValue("@nome", nomeUser);
                qry.Parameters.AddWithValue("@telefone", telefoneUser);
                qry.Parameters.AddWithValue("@senha", senhaUser);
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
