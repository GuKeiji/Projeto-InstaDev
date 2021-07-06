using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    // [Route ("Login")]
    public class Login : Controller
    {
        [TempData]
        public string MensagemErro { get; set; }

        Usuario UsuarioModel = new Usuario();

        // [Route("Listar")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]

        public IActionResult Logar(IFormCollection form)
        {
            List<string> UsuarioCSV = UsuarioModel.LerTodasAsLinhas("Database/Usuario.csv");

            var logado = UsuarioCSV.Find(
                x =>
                x.Split(";")[2] == form["Email"] &&
                x.Split(";")[3] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_username", logado.Split(";")[4]);
                HttpContext.Session.SetString("_Nome", logado.Split(";")[0]);
                return LocalRedirect("~/Feed/Listar");
            }
            // else
            // {
                MensagemErro = "Dados incorretos tente novamente !";
                return LocalRedirect("~/");
            // }
        }
        [Route("Logout")]

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_username");
            return LocalRedirect("~/");
        }
    }
}