using MySql.Data.MySqlClient;

namespace TickUp.Models
{
    public class Evento
    {

        static string conexao = "Server=localhost; Database=tickup;User id=root;Password=102938";
        private string assuntoEvento, categoriaEvento, nomeEvento, idEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino;
        private int capacidade;

        public string AssuntoEvento { get => assuntoEvento; set => assuntoEvento = value; }
        public string CategoriaEvento { get => categoriaEvento; set => categoriaEvento = value; }
        public string NomeEvento { get => nomeEvento; set => nomeEvento = value; }
        public string IdEvento { get => idEvento; set => idEvento = value; }
        public string EmailContato { get => emailContato; set => emailContato = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public string DataInicio { get => dataInicio; set => dataInicio = value; }
        public string DataTermino { get => dataTermino; set => dataTermino = value; }
        public string HorarioInicio { get => horarioInicio; set => horarioInicio = value; }
        public string HorarioTermino { get => horarioTermino; set => horarioTermino = value; }
        public int Capacidade { get => capacidade; set => capacidade = value; }

        public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string idEvento, string emailContato, string observacoes, string dataInicio, string dataTermino, string horarioInicio, string horarioTermino, int capacidade)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.idEvento = idEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.capacidade = capacidade;
        }

        public string Inserir()
        {

            MySqlConnection con = new MySqlConnection(conexao);
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO eventos VALUES(@assuntoEvento, @categoriaEvento, @nomeEvento, @idEvento, @emailContato, @observacoes, @dataInicio, @dataTermino, @horarioInicio, @horarioTermino, @capacidade)", con);
                qry.Parameters.AddWithValue("@assuntoEvento", assuntoEvento);
                qry.Parameters.AddWithValue("@categoriaEvento", categoriaEvento);
                qry.Parameters.AddWithValue("@nomeEvento", nomeEvento);
                qry.Parameters.AddWithValue("@idEvento", idEvento);
                qry.Parameters.AddWithValue("@emailContato", emailContato);
                qry.Parameters.AddWithValue("@observacoes", observacoes);
                qry.Parameters.AddWithValue("@dataInicio", dataInicio);
                qry.Parameters.AddWithValue("@dataTermino", dataTermino);
                qry.Parameters.AddWithValue("@horarioInicio", horarioInicio);
                qry.Parameters.AddWithValue("@horarioTermino", horarioTermino);
                qry.Parameters.AddWithValue("@capacidade", capacidade);
                qry.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                return "Erro: " + ex.InnerException;
            }

            return "Inserido com sucesso!";




        }

    }
}
