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
        public IActionResult PegarIngresso(string idEvento, int quantidadeIngresso, int capacidade)
        {
            FirebaseResponse response = client.Get(idEvento);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, Ingresso> ingressosDic = JsonConvert.DeserializeObject<Dictionary<string, Ingresso>>(response.Body);
                


                int ingressosRestantes = capacidade;

                    if (ingressosRestantes < quantidadeIngresso)
                    {
                        // Se não houver ingressos suficientes, definir a mensagem de erro e retornar a view de erro
                        ViewBag.ErrorMessage = "Não há ingressos suficientes disponíveis.";
               
                    }
                    else
                    {
                        // Se houver ingressos suficientes, prosseguir com o processamento dos ingressos
                        foreach (var ingresso in ingressosDic)
                        {
                            string idIngresso = ingresso.Key;
                            Ingresso ingressoModel = new Ingresso();
                            ingressoModel.IngressoComprado(idEvento, idIngresso, HttpContext);
                            client.Delete($"{idEvento}/{idIngresso}");
                            ingressosRestantes--;

                            // Verificar se a quantidade de ingressos restantes é menor que a quantidade desejada
                            if (ingressosRestantes < quantidadeIngresso)
                            {
                                // Se a quantidade de ingressos restantes for menor que a quantidade desejada,
                                // não é necessário continuar o loop, pois já sabemos que não há ingressos suficientes
                                break;
                            }
                        }

                        // Após o processamento dos ingressos, redirecionar para outra ação
                        return RedirectToAction("MostrarEvento", "Home");
                    }


            }


            return RedirectToAction("Index", "Home");
        }


        public IActionResult IngressosComprados()
        {
            Ingresso ingresso = new Ingresso();


            List<Evento> eventos = ingresso.ListarIngressos(HttpContext);

            return View(eventos);
        }





    }
}
