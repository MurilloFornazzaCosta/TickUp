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
        [HttpGet]
        public IActionResult PegarIngresso(string idEvento, int quantidadeIngresso)
        {
            FirebaseResponse response = client.Get(idEvento);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Dictionary<string, Ingresso> ingressosDic = JsonConvert.DeserializeObject<Dictionary<string, Ingresso>>(response.Body);

                Ingresso ingressoObj = new Ingresso();

                // Obter a capacidade do evento
                int capacidadeEvento = ingressoObj.ObterCapacidadeDoEvento(idEvento);

              
                    int ingressosRestantes =  ingressosDic.Count - quantidadeIngresso ;

                    if (ingressosRestantes < quantidadeIngresso)
                    {
                        // Se não houver ingressos suficientes, definir a mensagem de erro e retornar a view de erro
                        ViewBag.ErrorMessage = "Não há ingressos suficientes disponíveis.";
                        return View("Erro");
                    }
                    else
                    {
                        // Se houver ingressos suficientes, prosseguir com o processamento dos ingressos
                        int count = 0;
                        foreach (var ingresso in ingressosDic)
                        {
                            if (count >= quantidadeIngresso)
                            {
                                // Se já compramos a quantidade desejada de ingressos, sair do loop
                                break;
                            }

                            string idIngresso = ingresso.Key;
                            string mensagem = ingressoObj.IngressoComprado(idEvento, idIngresso, HttpContext);

                            if (mensagem == "Comprado com sucesso")
                            {
                                client.Delete($"{idEvento}/{idIngresso}");
                                count++;
                            }
                            else
                            {
                                ViewBag.ErrorMessage = mensagem;
                                return View("Error", "Shared");
                            }
                        }

                        // Após o processamento dos ingressos, redirecionar para outra ação
                        return RedirectToAction();
                    }

            }

            // Se não foi possível obter os dados do evento, redirecionar para a página inicial
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
