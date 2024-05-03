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

        public IActionResult CriarEvento(string assuntoEvento, string categoriaEvento, string nomeEvento, string idEvento, string emailContato, string observacoes, string dataInicio, string dataTermino, string horarioInicio, string horarioTermino, int capacidade)
        {
            Evento evento = new Evento(assuntoEvento, categoriaEvento, nomeEvento, idEvento, emailContato, observacoes, dataInicio, dataTermino, horarioInicio, horarioTermino, capacidade);
            TempData["msg"] = evento.Inserir();
            return RedirectToAction("CriarEvento");
        }
    }
}
