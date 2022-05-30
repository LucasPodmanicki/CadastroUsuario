using CadastroUsu.Models;

namespace CadastroUsu.Helper
{
    public interface ISessao
    {
        public void CriarSessaoUsuario(UsuarioModel usuario);

        public void RemoverSessaoUsuario();

        UsuarioModel BuscarSessaoUsuario();
    }
}
