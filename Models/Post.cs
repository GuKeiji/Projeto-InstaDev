using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Post : Instadev_Base, IPost
    {
        private int Id { get; set; }

        public string Legenda { get; set; }

        public string Imagem { get; set; }

        public Usuario EnviadoPor { get; set; }

        private const string CAMINHO = "Database/Post.csv";

        public Post()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        public void Criar(Post p)
        {
            string[] post = { Preparar(p) };

            File.AppendAllLines(CAMINHO, post);
        }

        public List<Post> ListarFeed(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Post> ListarPerfil(int id)
        {
            throw new System.NotImplementedException();
        }

        public string Preparar(Post p)
        {
            return $"{p.Id};{p.Legenda};{p.Imagem};{p.EnviadoPor}";
        }
    }
}