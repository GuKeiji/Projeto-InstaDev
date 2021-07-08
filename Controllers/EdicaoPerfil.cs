using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("EdicaoPerfil")]

    public class EdicaoPerfilController : Controller
    {
        Usuario usuarioDesatualizado = new Usuario();
        Post postPai = new Post();
        Usuario usuarioPai = new Usuario();
        public IActionResult Index()
        {
            Usuario UsuarioLogado = usuarioPai.LerDados().Find(x => x.RetornarId() == Int32.Parse(HttpContext.Session.GetString("_IdUsuario")));
            ViewBag.UsuarioLogado = UsuarioLogado;
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form)
        {
            Usuario UsuarioLogado = usuarioPai.LerDados().Find(x => x.RetornarId() == Int32.Parse(HttpContext.Session.GetString("_IdUsuario")));
            Usuario usuarioEditar = new Usuario();
            usuarioEditar.SetarSenha(UsuarioLogado.PegarSenha());
            usuarioEditar.AtribuirId(UsuarioLogado.PegarId());
            usuarioEditar.Nome = form["Nome"];
            usuarioEditar.Email = form["Email"];
            usuarioEditar.UserName = form["NomeUsuario"];
            // usuarioEditar.ImagemUsuario = form["ImagemUsuario"];
            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Usuario");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                usuarioEditar.ImagemUsuario = file.FileName;
            }
            else if (UsuarioLogado.ImagemUsuario != "padrao.png")
            {
                usuarioEditar.ImagemUsuario = UsuarioLogado.ImagemUsuario;
            }
            else
            {
                usuarioEditar.ImagemUsuario = "padrao.png";
            }
            UsuarioLogado.Alterar(usuarioEditar);
            // HttpContext.Session.Remove("_username");
            return LocalRedirect("~/EdicaoPerfil");
        }


        [Route("ExcluirConta")]
        public IActionResult Excluir(int id)
        {
            Usuario UsuarioLogado = usuarioPai.LerDados().Find(x => x.RetornarId() == Int32.Parse(HttpContext.Session.GetString("_IdUsuario")));
            usuarioPai.Deletar(UsuarioLogado.RetornarId());
            ViewBag.Usuarios = usuarioPai.LerDados();
            return LocalRedirect("~/");
        }
    }
}
