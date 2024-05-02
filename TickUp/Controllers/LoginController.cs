using Microsoft.AspNetCore.Mvc;

namespace TickUp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(); // Retorna a página de login
        }

        [HttpPost]
        public IActionResult ProcessLogin(string Email, string Password)
        {
            // Exemplo simples de verificação de login
            if (Email == "user@example.com" && Password == "senha123")
            {
                // Se as credenciais estiverem corretas, redirecionar para a página inicial
                return RedirectToAction("Index");
            }
            else
            {
                // Se as credenciais estiverem incorretas, retornar a página de login com uma mensagem de erro
                ViewBag.ErrorMessage = "E-mail ou senha incorretos";
                return View("Login");
            }
        }
    }
}
