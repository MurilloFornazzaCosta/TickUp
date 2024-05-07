using Microsoft.AspNetCore.Mvc;

namespace TickUp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult ProcessLogin(string Email, string Password)
        {
            if (Email == "user@example.com" && Password == "senha123")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "E-mail ou senha incorretos";
                return View("Login");
            }
        }
    }
}
