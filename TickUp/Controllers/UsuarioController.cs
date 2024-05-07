using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.IO.MemoryMappedFiles;
using System.Text.Json.Serialization;
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

        public IActionResult Login()
        {
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
            Usuario usuario = new Usuario(emailUser, "", "", "", senhaUser, 0);

            bool loginBemSucedido = Usuario.Login(usuario);

            if (loginBemSucedido)
            {
                HttpContext.Session.SetString("user", JsonConvert.SerializeObject(usuario));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Usuário ou senha incorretos.";
                return View();
            }
        }
        public IActionResult Logout()
        {
            var userSession = HttpContext.Session.GetString("user");

            if (userSession != null)
            {
                Usuario sairUsuario = JsonConvert.DeserializeObject<Usuario>(userSession);

                HttpContext.Session.Remove("user");
            }

            return RedirectToAction("Index", "Home");
        }

      }

}
