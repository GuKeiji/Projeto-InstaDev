using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Post postPai = new Post();
        Usuario UsuarioPai = new Usuario();
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Posts = postPai.ListarFeed();
            ViewBag.Usuarios = UsuarioPai.LerDados();
            ViewBag.UserName = HttpContext.Session.GetString("_username");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult CadastrarPost(IFormCollection form){
            ViewBag.Usuarios = UsuarioPai.LerDados();
            ViewBag.UserName = HttpContext.Session.GetString("_username");
            
            Post novoPost = new Post();
            novoPost.SetarId();
            novoPost.Legenda = form["Legenda"];
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgpost/Post");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgpost/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                novoPost.Imagem = file.FileName;
            }
            // else
            // {
            //     novoPost.Imagem = "semimagem.png";
            // }
            novoPost.nomeEnviado = HttpContext.Session.GetString("_username");
            postPai.Criar(novoPost);
            ViewBag.Posts = postPai.ListarFeed();

            return LocalRedirect("~/Feed/Listar");
        }

    }
}