using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Cadastrar()
        {
            if (TempData.ContainsKey("msg"))
            {
                ViewBag.Message = TempData["msg"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string emailUser, string cpfUser, string nomeUser, string senhaUser, string telefoneUser, int idadeUser)
        {
            Usuario user = new Usuario(emailUser, cpfUser, nomeUser, senhaUser, telefoneUser, idadeUser);
            TempData["msg"] = user.InserirUsuario();
            return RedirectToAction("Cadastrar");
        }

        public IActionResult Login()
        {
            if (TempData.ContainsKey("msg"))
            {
                ViewBag.Message = TempData["msg"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailUser, string cpfUser, string nomeUser, string senhaUser)
        {
            Usuario usuario = new Usuario(emailUser, cpfUser, nomeUser, senhaUser, "", 0);

            bool loginBemSucedido = Usuario.Login(usuario);

            if (loginBemSucedido)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(usuario));
                Response.Cookies.Append("user", JsonConvert.SerializeObject(usuario),
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(1)
                });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["msg"] = "Email ou senha incorreto";
                return RedirectToAction("Login");
            }
        }


        public IActionResult Logout()
        {
            var userSession = HttpContext.Session.GetString("user");

            if (userSession != null)
            {
                Usuario sairUsuario = JsonConvert.DeserializeObject<Usuario>(userSession);

                HttpContext.Session.Remove("user");

                //deslogando os cookies
                Response.Cookies.Delete("user");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
