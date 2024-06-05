using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using System.Collections.Generic;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class IngressoController : Controller
    {

        [ServiceFilter(typeof(Autentificacao))]
        public IActionResult PegarIngresso()
        {
            return View();
        }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "8bk6pzt4StGLmyg1h2ckiaODULn273DLyUeDeB7I",
            BasePath = "https://tickup-251a6-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public IngressoController()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch (Exception)
            {
                // Handle exception
            }
        }

        [HttpGet]
        public ActionResult PegarIngresso(string idEvento, int quantidadeIngresso)
        {
            FirebaseResponse response = client.Get(idEvento);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, Ingresso> ingressosDic = JsonConvert.DeserializeObject<Dictionary<string, Ingresso>>(response.Body);
                int ingressosRestantes = ingressosDic.Count;

                if (ingressosRestantes < quantidadeIngresso)
                {
                    TempData["msg"] = "Não há ingressos suficientes disponíveis.";
                    return RedirectToAction("MostrarEvento", "Home", new { id = idEvento });

                }
                else
                {
                    int count = 0;
                    foreach (var ingresso in ingressosDic)
                    {
                        if (count >= quantidadeIngresso)
                        {
                            break;
                        }

                        string idIngresso = ingresso.Key;
                        string mensagem = new Ingresso().IngressoComprado(idEvento, idIngresso, HttpContext);

                        if (mensagem == "Comprado com sucesso")
                        {
                            client.Delete($"{idEvento}/{idIngresso}");
                            count++;
                        }
                        else
                        {
                            TempData["msg"] = mensagem;
                            return RedirectToAction("Login", "Usuario");
                        }
                    }
   
                    return RedirectToAction("Index", "Home");
                }
            }
          
            return RedirectToAction("MostrarEvento", "Evento");
        }



        public IActionResult IngressosComprados()
        {
            Ingresso ingresso = new Ingresso();


            List<Evento> eventos = ingresso.ListarIngressos(HttpContext);

            return View(eventos);
        }





    }
}
