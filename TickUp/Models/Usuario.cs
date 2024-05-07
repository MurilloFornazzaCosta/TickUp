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


        public Usuario(string emailUser, string cpfUser, string nomeUser, string telefoneUser,
                       string senhaUser, int idadeUser)
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
                    "INSERT INTO usuarios (email, cpf, nome, telefone, senha, idade) VALUES (@Email, @Cpf, @Nome, @Telefone, @Senha, @Idade)", con);
                qry.Parameters.AddWithValue("@Email", emailUser);
                qry.Parameters.AddWithValue("@Cpf", cpfUser);
                qry.Parameters.AddWithValue("@Nome", nomeUser);
                qry.Parameters.AddWithValue("@Telefone", telefoneUser);
                qry.Parameters.AddWithValue("@Senha", senhaUser);
                qry.Parameters.AddWithValue("@Idade", idadeUser);

                qry.ExecuteNonQuery();

                return "Usuário inserido com sucesso!";
            }
            catch (Exception ex)
            {
                return $"Erro ao inserir usuário: {ex.Message}"; 
            }
            finally
            {
                con.Close(); 
            }
        }

        public static bool Login( Usuario usuario)
        {
            MySqlConnection con = FabricaConexao.getConexao("casaGustavo");
            try
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM usuarios WHERE email = @email AND senha = @senha";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email", usuario.EmailUser);
                    cmd.Parameters.AddWithValue("@senha", usuario.SenhaUser);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar login: {ex.Message}"); 
                return false; 
            }
            finally
            {
                con.Close(); 
            }
        }
    }
}
