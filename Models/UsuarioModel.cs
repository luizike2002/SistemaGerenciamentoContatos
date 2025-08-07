using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage ="O Nome é obrigatório.")]
        [StringLength(90,MinimumLength = 4, ErrorMessage ="O Valor Minimo de caracteres é 4")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Login é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Valor Minimo de caracteres é 1")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "O Valor Minimo de caracteres é 4")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Perfil é obrigatório.")]
        public PerfilEnum Perfil { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        [StringLength(9000, MinimumLength = 6, ErrorMessage = "O Valor Minimo de caracteres é 6")]
        public string Senha { get; set; }


        public DateTime DataDeCadastro { get; set; }
        public DateTime? DataDeAtualizacao { get; set; }
        public virtual List<ContatoModel> Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
