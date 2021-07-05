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
            ViewBag.Posts = postModel.ListarPerfil(usuarioModel);
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
            return LocalRedirect("~/Home");
        }
    }
}