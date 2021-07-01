using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IPost
    {
        void Criar(Post p);
        string Preparar(Post p);
        List<Post> ListarFeed();
        List<Post> ListarPerfil(int id);

    }
}