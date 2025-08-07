using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ControleDeContatos.Repositories
{
    public class UsuarioRepositorie : IUsuarioRepositorio
    {

        private readonly BancoContext _bancoDbContext;
        public UsuarioRepositorie(BancoContext bancoContext)
        {
            _bancoDbContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoDbContext.Usuarios.FirstOrDefault(o => o.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataDeCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _bancoDbContext.Usuarios.Add(usuario);
            _bancoDbContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null) throw new Exception("Ouve um Erro na deleção do Usuario");
            _bancoDbContext.Usuarios.Remove(usuarioDB);
            _bancoDbContext.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.UsuarioId);
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataDeAtualizacao = DateTime.Now;

            _bancoDbContext.Usuarios.Update(usuarioDB);
            _bancoDbContext.SaveChanges();
            return usuarioDB;
        }


        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoDbContext.Usuarios.Include(x => x.Contatos).ToList();
        }


        public UsuarioModel ListarPorId(int id)
        {
            return _bancoDbContext.Usuarios.FirstOrDefault(o => o.UsuarioId == id);
        }

        public UsuarioModel BuscarPorLogineEmail(string login, string email)
        {
            return _bancoDbContext.Usuarios.FirstOrDefault(o => o.Login.ToUpper() == login.ToUpper() && o.Email.ToUpper() == email.ToUpper());
        }



        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na alteração da senha, usuario não encontrado!");
            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere");
            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Digite uma senha diferente da atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataDeAtualizacao = DateTime.Now;
            _bancoDbContext.Usuarios.Update(usuarioDB);
            _bancoDbContext.SaveChanges();

            return usuarioDB;
        }
    }
}
