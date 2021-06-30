using System.Collections.Generic;
using System.IO;
using ProjetoInstaDev.Interfaces;

namespace ProjetoInstaDev.Models
{
    public class Post : Instadev_Base, IPost
    {
        public void Criar(Post p)
        {
            throw new System.NotImplementedException();
        }

        public List<Post> ListarFeed(int id)
        {
            List<Post> posts = new List<Post>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Post post = new Post();
                
                post.Id = linha[0];
                post.Legenda = linha[1];
                post.Imagem = linha[2];
                post.EnviadoPor
                posts.Add(post); 
            }
            return posts;
        }

        public List<Post> ListarPerfil(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Preparar(Post p)
        {
            throw new System.NotImplementedException();
        }
    }
}