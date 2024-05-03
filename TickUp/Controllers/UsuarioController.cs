using Microsoft.AspNetCore.Mvc;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(string emailUser, string cpfUser, string nomeUser, string telefoneUser, string senhaUser, int idadeUser)
        {
            Usuario user = new Usuario(emailUser, cpfUser, nomeUser, telefoneUser, senhaUser, idadeUser);
            TempData["msg"] = user.InserirUsuario();
            return RedirectToAction("Cadastrar");
        }
    }
           
}
