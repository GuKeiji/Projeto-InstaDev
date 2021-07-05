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
        [Route("Listar")]
        public IActionResult Index(){
            ViewBag.Usuarios = UsuarioModel.ListarDados();
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Usuario Novousuario = new Usuario();
            var Nu = Novousuario.PegarSenha();
            
            Novousuario.Nome = form["Nome"];
            // Novousuario.SetarId(Novousuario.GerarId(Novousuario.PegarId()));
            Novousuario.Email = form["Email"];
            Nu = form["Senha"];
            Novousuario.UserName = form["UserName"];

            UsuarioModel.Criar(Novousuario);
            ViewBag.Usuarios = UsuarioModel.ListarDados();

            return LocalRedirect("~/Usuario/Listar");
        }
    }
}