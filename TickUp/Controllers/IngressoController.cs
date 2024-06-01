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
        public IActionResult PegarIngresso(string idEvento, int quantidadeIngresso)
        {
            FirebaseResponse response = client.Get(idEvento);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, Ingresso> ingressosDic = JsonConvert.DeserializeObject<Dictionary<string, Ingresso>>(response.Body);

                int count = 0;

                foreach (var ingresso in ingressosDic)
                {
                    if (count >= quantidadeIngresso)
                    {
                        break;
                    }

                    string idIngresso = ingresso.Key;
                    Ingresso ingressoModel = new Ingresso();
                    ingressoModel.IngressoComprado(idEvento, idIngresso, HttpContext);
                    client.Delete($"{idEvento}/{idIngresso}");
                    count++;
                }
            }

            return RedirectToAction("CriarEvento", "Evento");
        }


        public IActionResult IngressosComprados()
        {
            Ingresso ingresso = new Ingresso();


            List<Evento> eventos = ingresso.ListarIngressos(HttpContext);

            return View(eventos);
        }





    }
}
