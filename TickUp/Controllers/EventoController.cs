using Microsoft.AspNetCore.Mvc;
using TickUp.Models;

namespace TickUp.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult CriarEvento()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CriarEvento(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade)
        {



            foreach (IFormFile arq in Request.Form.Files){
                
                MemoryStream stream = new MemoryStream();
                arq.CopyTo(stream);
                byte[] bytesImagem = stream.ToArray();
                Evento evento = new Evento(
                        assuntoEvento,
                        categoriaEvento,
                        nomeEvento,
                        emailContato,
                        observacoes,
                        horarioInicio,
                        horarioTermino,
                        cpf,
                        email,
                        dataInicio,
                        dataTermino,
                        capacidade,
                        bytesImagem,
                        nomeLocal,
                        cep,
                        rua,
                        numero,
                        complemento,
                        bairro,
                        estado,
                        cidade
                    );
                TempData["msg"] = evento.Inserir();

            }

            return RedirectToAction("CriarEvento");
        }

    }
}
