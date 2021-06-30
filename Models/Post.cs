using System.Collections.Generic;
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
            throw new System.NotImplementedException();
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