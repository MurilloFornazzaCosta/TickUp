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
            return View();
        }

        public IActionResult Restaurante() 
        { 
            return View(); 
        }

        public IActionResult ShowFestas()
        {
            return View();
        }

        public IActionResult StandUp()
        {
            return View();
        }

        public IActionResult Teatros()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
