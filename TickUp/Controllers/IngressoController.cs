using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class IngressoController : Controller
    {


    public IActionResult Index()
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
                    ingressoModel.IngressoComprado(idEvento, idIngresso);
                    count++;
                }
            }

            return RedirectToAction("CriarEvento", "Evento");
        }

    }
}
