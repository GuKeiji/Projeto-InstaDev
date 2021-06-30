using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IPost
    {
        void Criar(Post p);
        void Preparar(Post p);
        List<Post> ListarFeed(int id);
        List<Post> ListarPerfil(int id);

    }
}