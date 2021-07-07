using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("EdicaoPerfil")]

    public class EdicaoPerfilController : Controller
    {
        Usuario usuarioDesatualizado = new Usuario();
        public IActionResult Index()
        {
            return View();
        }

        [Route("Editar")]
        public IActionResult Editar(IFormCollection form)
        {
            Usuario usuarioEditar = new Usuario();

            List<Usuario> UsuarioCSV = usuarioDesatualizado.LerDados();
            var logado = UsuarioCSV.Find(x => x.RetornarId() == Int32.Parse(HttpContext.Session.GetString("IdUsuario")));

            usuarioEditar.Nome = form["Nome"];
            usuarioEditar.Email = form["Email"];
            usuarioEditar.UserName = form["NomeUsuario"];
            // usuarioEditar.ImagemUsuario = form["ImagemUsuario"];

            usuarioEditar.PegarId(logado.RetornarId());
            usuarioEditar.PegarSenha(logado.RetornarSenha());

            logado.Alterar(usuarioEditar);

            return LocalRedirect("~/EdiçãoPerfil");
        }


        [Route("ExcluirConta")]
        public IActionResult Excluir()
        {



            return LocalRedirect("~/Usuario/PaginaCadastro");
        }
    }
}