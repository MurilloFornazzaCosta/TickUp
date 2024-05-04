using Microsoft.AspNetCore.Mvc;
using TickUp.Models; // Use seu namespace correto

namespace TickUp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            // Se TempData contém mensagem, passamos para a view
            if (TempData.ContainsKey("msg"))
            {
                ViewBag.Message = TempData["msg"];
            }
            return View();
        }

        public IActionResult Login()
        {
            // Se ViewBag contém mensagem de erro, exibimos na view
            if (ViewBag.ErrorMessage != null)
            {
                ViewBag.ErrorMessage = ViewBag.ErrorMessage;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string emailUser, string cpfUser, string nomeUser, string telefoneUser, string senhaUser, int idadeUser)
        {
            Usuario user = new Usuario(emailUser, cpfUser, nomeUser, telefoneUser, senhaUser, idadeUser);
            TempData["msg"] = user.InserirUsuario();
            return RedirectToAction("Cadastrar");
        }

        [HttpPost]
        public IActionResult Login(string emailUser, string senhaUser)
        {
            Usuario usuarioParaLogin = new Usuario(emailUser, "", "", "", senhaUser, 0);

            bool loginBemSucedido = Usuario.Login(usuarioParaLogin);


            if (loginBemSucedido)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuário ou senha incorretos.";
                return View();
            }
        }



    }

}
