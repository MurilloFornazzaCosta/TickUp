using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Evento.ListarEventos());
        }

        public IActionResult MostrarEvento(string id)
        {

            return View(Evento.MostrarEvento(id));
        }

        public IActionResult Palestras()
        {
            return View(Evento.MostrarEventoPalestras());
        }

        public IActionResult Restaurante() 
        { 
            return View(Evento.MostrarEventoRestaurantes()); 
        }

        public IActionResult ShowFestas()
        {
            return View(Evento.MostrarEventoShows());
        }

        public IActionResult StandUp()
        {
            return View(Evento.MostrarEventoStandUp());
        }

        public IActionResult Teatros()
        {
            return View(Evento.MostrarEventoTeatros());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
