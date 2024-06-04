using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.IO;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using HtmlAgilityPack;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TickUp.Models
{
    public class Evento
    {

        private string idEvento, assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, horarioInicio, horarioTermino, cpf, email;
        private DateOnly dataInicio, dataTermino;
        private int capacidade;
        private byte[] bytesImagem;

        private string nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade;

        public double valorIngresso;
        private int quantidadeIngresso;


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
        public string IdEvento { get => idEvento; set => idEvento = value; }
        public int QuantidadeIngresso { get => quantidadeIngresso; set => quantidadeIngresso = value; }

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

            public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string idEvento, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.idEvento = idEvento;
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

            public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string idEvento, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, double valorIngresso)
        {
            this.assuntoEvento = assuntoEvento;
            this.categoriaEvento = categoriaEvento;
            this.nomeEvento = nomeEvento;
            this.emailContato = emailContato;
            this.observacoes = observacoes;
            this.idEvento = idEvento;
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

        public Evento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes,  string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, double valorIngresso)
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


        public Evento()
        {

        }

        public string Inserir(HttpContext httpContext)
        {
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");

            try
            {
                con.Open();

                string userSession = httpContext.Session.GetString("user");
                if (string.IsNullOrEmpty(userSession))
                {
                    return "Erro: Sessão de usuário não encontrada.";
                }

                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(userSession);
                string email = usuario.EmailUser;

                MySqlCommand selectQry = new MySqlCommand("SELECT cpf FROM usuario WHERE email = @Email", con);
                selectQry.Parameters.AddWithValue("@Email", email);

                string cpf = string.Empty;
                using (MySqlDataReader reader = selectQry.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cpf = reader["cpf"].ToString();
                    }

                }
                    MySqlCommand qry = new MySqlCommand(
                    "insert into evento (dataInicio, horarioInicio, categoriaEvento, nomeEvento, emailContato, observacoes, assuntoEvento, imagem, horarioTermino, dataTermino, capacidade, cpf, email, numero, rua, bairro, nomeLocal, cidade, estado, cep, complemento, valorIngresso) VALUES (@dataInicio, @horarioInicio, @categoriaEvento, @nomeEvento, @emailContato, @observacoes, @assuntoEvento, @imagem, @horarioTermino, @dataTermino, @capacidade, @cpf, @email, @numero, @rua, @bairro, @nomeLocal, @cidade, @estado, @cep, @complemento, @valorIngresso)", con);

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
                    qry.Parameters.AddWithValue("@cpf", cpf);
                    qry.Parameters.AddWithValue("@email", email); 
                    qry.Parameters.AddWithValue("@numero", numero);
                    qry.Parameters.AddWithValue("@rua", rua);
                    qry.Parameters.AddWithValue("@bairro", bairro);
                    qry.Parameters.AddWithValue("@nomeLocal", nomeLocal);
                    qry.Parameters.AddWithValue("@cidade", cidade);
                    qry.Parameters.AddWithValue("@estado", estado);
                    qry.Parameters.AddWithValue("@cep", cep);
                    qry.Parameters.AddWithValue("@complemento", complemento);
                    qry.Parameters.AddWithValue("@imagem", bytesImagem);
                    qry.Parameters.AddWithValue("@valorIngresso", valorIngresso);

                    qry.ExecuteNonQuery();

                    con.Close();
                }
            catch (Exception ex)
            {
                return "Erro: " + ex.Message; 
            }

            return "Inserido com sucesso!";
        }
        public static Evento MostrarEvento(string idEvento)
        {
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE idEvento = @idEvento ;", con);
                qry.Parameters.AddWithValue("@idEvento", idEvento);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        return evento;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                DateOnly dataVazia = new DateOnly(0000, 00, 00);
                Evento eventoVazio = new Evento("", "", "", "", "", "", "", "", "", dataVazia, dataVazia, 0, [], "", "", "", "", "", "", "", "");

                return eventoVazio;

            }

            DateOnly dataVazia2 = new DateOnly(0000, 00, 00);
            Evento eventoVazio2 = new Evento("", "", "", "", "", "", "", "", "", dataVazia2, dataVazia2, 0, [], "", "", "", "", "", "", "", "");
            return eventoVazio2;

        }


        public static List<Evento> MostrarEventoShows()
        {
            List<Evento> eventosShows = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE categoriaEvento = 'Shows' ;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        eventosShows.Add(evento);

                        return eventosShows;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {

                return eventosShows;

            }
  
            return eventosShows;

        }

        public static List<Evento> MostrarEventoRestaurantes()
        {
            List<Evento> eventosRestaurantes = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE categoriaEvento = 'Restaurantes' ;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        eventosRestaurantes.Add(evento);

                        return eventosRestaurantes;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {

                return eventosRestaurantes;

            }

            return eventosRestaurantes;

        }

        public static List<Evento> MostrarEventoPalestras()
        {
            List<Evento> eventosPalestras = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE categoriaEvento = 'Palestras' ;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        eventosPalestras.Add(evento);

                        return eventosPalestras;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {

                return eventosPalestras;

            }

            return eventosPalestras;

        }


        public static List<Evento> MostrarEventoTeatros()
        {
            List<Evento> eventosTeatros = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE categoriaEvento = 'Teatros' ;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        eventosTeatros.Add(evento);

                        return eventosTeatros;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {

                return eventosTeatros;

            }

            return eventosTeatros;

        }

        public static List<Evento> MostrarEventoStandUp()
        {
            List<Evento> eventosStandUp = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento WHERE categoriaEvento = 'Stand Up' ;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
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
                        double valorIngresso = (double)reader["valorIngresso"];

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
                            cidade,
                            valorIngresso

                        );

                        eventosStandUp.Add(evento);

                        return eventosStandUp;

                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {

                return eventosStandUp;

            }

            return eventosStandUp;

        }

        public static List<Evento> ListarEventos()
            {
            List<Evento> eventos = new List<Evento>();
            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            try
            {
                con.Open();                
                MySqlCommand qry = new MySqlCommand(
                    "select * from evento", con);
                MySqlDataReader reader = qry.ExecuteReader();
                reader.Read();
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
                con.Close();

            }
            catch(Exception ex)
            {

                return eventos;

            }

            return eventos;

        }
        public string ObterUltimoIdEvento()
        {
            string ultimoId = "";

            MySqlConnection con = FabricaConexao.getConexao("jawsdb");
            {
                con.Open();

                MySqlCommand qry = new MySqlCommand(
                   "select MAX(idEvento) FROM evento;", con);

                using (MySqlDataReader reader = qry.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string idEvento = reader["MAX(idEvento)"].ToString();
                        ultimoId = idEvento;
                    }
                }
                con.Close();
            }

            return ultimoId;

        }


    }
}
