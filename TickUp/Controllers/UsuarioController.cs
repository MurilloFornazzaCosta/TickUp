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
        public IActionResult Cadastrar(string nome, string email, int idade, string telefone, string senha, string cpf)
        {
            Usuario user = new Usuario(email, cpf, nome, telefone, senha, idade);
            TempData["msg"] = user.InserirUSuario();
            return RedirectToAction("Cadastrar");
        }
    }
}
