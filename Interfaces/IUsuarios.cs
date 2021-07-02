using System.Collections.Generic;
using ProjetoInstaDev.Models;

namespace ProjetoInstaDev.Interfaces
{
    public interface IUsuario
    {
        void Criar(Usuario u);
        string Preparar(Usuario u);
        List<Usuario> LerDados();
        void Alterar(Usuario u);
        void Deletar(int id);
    }
}