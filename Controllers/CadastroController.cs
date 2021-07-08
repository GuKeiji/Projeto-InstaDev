using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoInstaDev.Models;

namespace Projeto_InstaDev.Controllers
{
    [Route("Usuario")]
    public class CadastroController : Controller
    {

        Usuario UsuarioModel = new Usuario();
        [Route("PaginaCadastro")]
        public IActionResult Index(){
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Usuario Novousuario = new Usuario();

            Novousuario.Nome = form["Nome"];
            // Novousuario.SetarId(Novousuario.GerarId(Novousuario.PegarId()));
            Novousuario.Email = form["Email"];
            Novousuario.SetarSenha(form["Senha"]);
            Novousuario.UserName = form["UserName"];
            Novousuario.SetarId();

            UsuarioModel.Criar(Novousuario);

            return LocalRedirect("~/");
        }
    }
}