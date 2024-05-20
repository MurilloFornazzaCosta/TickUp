﻿using MySql.Data.MySqlClient;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TickUp.Models
{
    public class Evento
    {

        private string assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino;
        private int capacidade;
        private byte[] bytesImagem;

        //Varievis de ingresso
        private int quantidadeLimite;
        private double valor;

        public string AssuntoEvento { get => assuntoEvento; set => assuntoEvento = value; }
        public string CategoriaEvento { get => categoriaEvento; set => categoriaEvento = value; }
        public string NomeEvento { get => nomeEvento; set => nomeEvento = value; }
        public string EmailContato { get => emailContato; set => emailContato = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public string DataInicio { get => dataInicio; set => dataInicio = value; }
        public string DataTermino { get => dataTermino; set => dataTermino = value; }
        public string HorarioInicio { get => horarioInicio; set => horarioInicio = value; }
        public string HorarioTermino { get => horarioTermino; set => horarioTermino = value; }
        public int Capacidade { get => capacidade; set => capacidade = value; }
        public byte[] BytesImagem { get => bytesImagem; set => bytesImagem = value; }

        public int QuantidadeLimite { get => quantidadeLimite; set => quantidadeLimite = value; }
        public double Valor { get => valor; set => valor = value; }


        public Evento(int quantidadeLimite, double valor, string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string dataInicio, string dataTermino, string horarioInicio, string horarioTermino, int capacidade, byte[] bytesImagem)
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
            
            this.quantidadeLimite = quantidadeLimite;
            this.valor = valor;
        }



        public string Inserir()
        {

            MySqlConnection con = FabricaConexao.getConexao("casaGustavo");
            try
            {
                
                con.Open();
                MySqlCommand qry = new MySqlCommand(
                    "INSERT INTO eventos (assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino, capacidade, imagem) VALUES(@assuntoEvento, @categoriaEvento, @nomeEvento, @emailContato, @observacoes, @dataInicio, @dataTermino, @horarioInicio, @horarioTermino, @capacidade, @imagem)", con);
                qry.Parameters.AddWithValue("@assuntoEvento", assuntoEvento);
                qry.Parameters.AddWithValue("@categoriaEvento", categoriaEvento);
                qry.Parameters.AddWithValue("@nomeEvento", nomeEvento);
                qry.Parameters.AddWithValue("@emailContato", emailContato);
                qry.Parameters.AddWithValue("@observacoes", observacoes);
                qry.Parameters.AddWithValue("@dataInicio", dataInicio);
                qry.Parameters.AddWithValue("@dataTermino", dataTermino);
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


        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8bk6pzt4StGLmyg1h2ckiaODULn273DLyUeDeB7I",
            BasePath = "https://tickup-251a6-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;
        public string Firebase()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                Console.WriteLine($"Conectado com sucesso");
            }
        }

    }
}
