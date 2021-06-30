using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IUsuario
    {
        void Criar(Usuario u);
        void Preparar(Usuario u);
        List<Usuario> ListarDados();
        void Alterar(Usuario u);
        void Deletar(int id);
    }
}