using CadastroUsu.Models;
using System.Collections.Generic;

namespace CadastroUsu.Repositorio
{
    public interface IUsuarioRepositorio
    {
        // Chamar metodos no banco

        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel BuscarPorID(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }
}