using Microsoft.AspNetCore.Mvc;
using TickUp.Models;

using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Extensions.Primitives;


namespace TickUp.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult CriarEvento()
        {
            return View();
        }

        public IActionResult MostrarEvento()
        {

            return View();
        }

        [HttpPost]

        public IActionResult CriarEvento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade,double valorIngresso)
        {



            foreach (IFormFile arq in Request.Form.Files){
                
                MemoryStream stream = new MemoryStream();
                arq.CopyTo(stream);
                byte[] bytesImagem = stream.ToArray();
                Evento evento = new Evento(
                        assuntoEvento,
                        categoriaEvento,
                        nomeEvento,
                        emailContato,
                        observacoes,
                        horarioInicio,
                        horarioTermino,
                        cpf,
                        email,
                        dataInicio,
                        dataTermino,
                        capacidade,
                        bytesImagem,
                        nomeLocal,
                        cep,
                        rua,
                        numero,
                        complemento,
                        bairro,
                        estado,
                        cidade
                        
                    );
                Evento eventoIngresso = new Evento(assuntoEvento,
                        categoriaEvento,
                        nomeEvento,
                        emailContato,
                        observacoes,
                        horarioInicio,
                        horarioTermino,
                        cpf,
                        email,
                        dataInicio,
                        dataTermino,
                        capacidade,
                        bytesImagem,
                        nomeLocal,
                        cep,
                        rua,
                        numero,
                        complemento,
                        bairro,
                        estado,
                        cidade,
                        valorIngresso);

                TempData["msg"] = evento.Inserir();


                string idEvento = evento.ObterUltimoIdEvento();
               
                    for (int i = 0; i != capacidade; i++)
                    {
                        string idIngresso = Guid.NewGuid().ToString();

                    SetResponse response = client.Set(idEvento + "/" + idIngresso, eventoIngresso);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                        }
                    }
            
                }


            return RedirectToAction("CriarEvento");
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8bk6pzt4StGLmyg1h2ckiaODULn273DLyUeDeB7I",
            BasePath = "https://tickup-251a6-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public EventoController()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);

            }
            catch (Exception)
            {

            }
        }


    }

}
