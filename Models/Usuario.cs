using System;
using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Usuario : Instadev_Base, IUsuario
    {
        public string Nome { get; set; }
        private int Id;
        public string Email { get; set; }
        private string Senha;
        public string UserName { get; set;}
        public string ImagemUsuario { get; set;}

        private const string CAMINHO = "Database/Usuario.csv";
        public Usuario(){
            CriarPastaEArquivo(CAMINHO);
        }
        public void Alterar(Usuario u)
        {
            List<string> linhas = LerTodasAsLinhas(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[4] == u.UserName.ToString());
            linhas.Add(Preparar(u));
            ReescrevaCSV(CAMINHO, linhas);
        }

        public void Criar(Usuario u)
        {
            string[] linha = {Preparar(u)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasAsLinhas(CAMINHO);
            linhas.RemoveAll(x =>x.Split(";")[0] == id.ToString());
            ReescrevaCSV(CAMINHO, linhas);
        }

        public List<Usuario> LerDados()
        {
            List<Usuario> usuario = new List<Usuario>();

             string[] linhas = File.ReadAllLines(CAMINHO);
             foreach (var item in linhas)
             {
                 string [] linha = item.Split(";");

                 Usuario usuario1 = new Usuario();

                 usuario1.Nome = linha[0];
                 usuario1.Id = Int32.Parse(linha[1]);
                 usuario1.Email = linha[2];
                 usuario1.Senha = linha[3];
                 usuario1.UserName = linha[4];
                 usuario1.ImagemUsuario = linha[5];
                 usuario.Add(usuario1);
             }
             return usuario;
        }

        public string Preparar(Usuario u)
        {
            return $"{u.Nome};{u.Id};{u.Email};{u.Senha};{u.UserName};{u.ImagemUsuario}";
        }
    }
}