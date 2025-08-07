using ControleDeContatos.Controllers;
using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface Isessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario();
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
