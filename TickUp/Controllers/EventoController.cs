using Microsoft.AspNetCore.Mvc;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult CriarEvento()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CriarEvento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, DateOnly dataInicio, DateOnly dataTermino, string horarioInicio, string horarioTermino, int capacidade)
        {



            foreach (IFormFile arq in Request.Form.Files){
                
                    MemoryStream stream = new MemoryStream();
                    arq.CopyTo(stream);
                    byte[] bytesImagem = stream.ToArray();
                    Evento evento = new Evento(assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino, capacidade, bytesImagem);
                    TempData["msg"] = evento.Inserir();
                
                
            }

            return RedirectToAction("CriarEvento");
        }

    }
}
