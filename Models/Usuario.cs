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

        private const string CAMINHO = "Database/Usuario";
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
            throw new System.NotImplementedException();
        }

        public List<Usuario> ListarDados()
        {
            throw new System.NotImplementedException();
        }

        public string Preparar(Usuario u)
        {
            return $"{u.Nome};{u.Id};{u.Email};{u.Senha};{u.UserName};{u.ImagemUsuario}";
        }
    }
}