using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos(int usuarioId);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel ListarPorId (int id);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
    