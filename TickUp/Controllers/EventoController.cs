using Microsoft.AspNetCore.Mvc;

namespace TickUp.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
