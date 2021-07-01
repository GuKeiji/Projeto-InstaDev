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
        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Posts = postPai.ListarFeed();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult CadastrarPost(IFormCollection form){
            Post novoPost = new Post();
            novoPost.Legenda = form["Legenda"];
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

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
            postPai.SetarId(postPai.GerarId(postPai.PegarId()));
            postPai.Criar(novoPost);
            ViewBag.Posts = postPai.ListarFeed();




            return LocalRedirect("~/Feed/Listar");
        }

    }
}