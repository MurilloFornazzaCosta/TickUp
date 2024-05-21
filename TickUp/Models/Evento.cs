using MySql.Data.MySqlClient;

namespace TickUp.Models
{
    public class Evento
    {

        private string assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, horarioInicio, horarioTermino;
        private DateOnly dataInicio, dataTermino;
        private int capacidade;
        private byte[] bytesImagem;

        private string nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade, endereco;

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


        public string NomeLocal { get => nomeLocal; set => nomeLocal = value; }
        public string Cep { get => cep; set => cep = value; }
        public string Rua { get => rua; set => rua = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Complemento { get => complemento; set => complemento = value; }
        public string Bairro { get => bairro; set => bairro = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Cidade { get => cidade; set => cidade = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        


        public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, DateOnly dataInicio, DateOnly dataTermino, string horarioInicio, string horarioTermino, int capacidade, byte[] bytesImagem)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.capacidade = capacidade;
            this.bytesImagem = bytesImagem;
        }

        // TALVEZ TIRAR COMPLEMENTO E NUMERO DO CONSTRUTOR
        public Evento(string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, string endereco)
        {
            this.nomeLocal = nomeLocal;
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.estado = estado;
            this.cidade = cidade;
            this.endereco = endereco;
        }

        public string InserirLocal()
        {

            MySqlConnection con = FabricaConexao.getConexao("casaMurillo");
            try
            {

                con.Open();
                MySqlCommand qry = new MySqlCommand(// MUDAR A ORDEM AQUI!!!
                    "INSERT INTO locais (nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade, endereco) VALUES(@nomeLocal, @cep, @rua, @numero, @complemento, @bairro, @estado, @cidade, @endereco)", con);
                qry.Parameters.AddWithValue("@nomeLocal", nomeLocal);
                qry.Parameters.AddWithValue("@cep", cep);
                qry.Parameters.AddWithValue("@rua", rua);
                qry.Parameters.AddWithValue("@numero", numero);
                qry.Parameters.AddWithValue("@complemento", complemento);
                qry.Parameters.AddWithValue("@bairro", bairro);
                qry.Parameters.AddWithValue("@estado", estado);
                qry.Parameters.AddWithValue("@cidade", cidade);
                qry.Parameters.AddWithValue("@endereco", endereco);
                qry.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                return "Erro: " + ex.InnerException;
            }

            return "Inserido com sucesso!";

        }

        public string Inserir()
        {

            MySqlConnection con = FabricaConexao.getConexao("casaMurillo");
            try
            {
                
                con.Open();
                MySqlCommand qry = new MySqlCommand(// MUDAR A ORDEM AQUI!!!
                    "INSERT INTO eventos (assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino, capacidade, imagem) VALUES(@assuntoEvento, @categoriaEvento, @nomeEvento, @emailContato, @observacoes, @dataInicio, @dataTermino, @horarioInicio, @horarioTermino, @capacidade, @imagem)", con);
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
            MySqlConnection con = FabricaConexao.getConexao("casaMurillo");
            try
            {
                con.Open();                
                MySqlCommand qry = new MySqlCommand(
                    "SELECT * FROM eventos", con);
                MySqlDataReader reader = qry.ExecuteReader();
                reader.Read();
                while (reader.Read())
                {
                   
                    string assunto = reader["assuntoEvento"].ToString();
                    string categoria = reader["categoriaEvento"].ToString();
                    string nome = reader["nomeEvento"].ToString();
                    string id = reader["idEvento"].ToString();
                    string emailContato = reader["emailContato"].ToString();
                    string observacoes = reader["observacoes"].ToString();
                    DateOnly dataInicio = DateOnly.Parse(reader["dataInicio"].ToString());
                    DateOnly dataTermino = DateOnly.Parse(reader["dataTermino"].ToString()) ;
                    string horarioInicio = reader["horarioInicio"].ToString();
                    string horarioTermino = reader["horarioTermino"].ToString();
                    int capacidade = (int)reader["capacidade"];
                    byte[] byteImagem = (byte[])reader["imagem"];
                    string imagem = Convert.ToBase64String(byteImagem);
                    Evento evento = new Evento(assunto, categoria, nome, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino, capacidade, byteImagem);

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
