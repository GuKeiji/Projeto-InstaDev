using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.ListarDados();
            ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar()
        {
            return LocalRedirect("~/EditarPerfil");
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");

            return LocalRedirect("~/Login");
        }
    }
}