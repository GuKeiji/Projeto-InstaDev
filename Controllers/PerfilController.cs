using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("Perfil")]
    public class PerfilController : Controller
    {
        Usuario usuarioModel = new Usuario();
        Post postModel = new Post();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.LerDados();
            ViewBag.UserName = HttpContext.Session.GetString("_username");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            ViewBag.Post = postModel.ListarPerfil(HttpContext.Session.GetString("_username"));
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar()
        {
            return LocalRedirect("~/EdicaoPerfil");
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/Login");
        }
    }
}