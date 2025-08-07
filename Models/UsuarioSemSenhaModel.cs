using ControleDeContatos.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    [Table("UsuarioSemSenha")]
    public class UsuarioSemSenhaModel 
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(90, MinimumLength = 1, ErrorMessage = "O Valor Minimo de caracteres é 4")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Login é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Valor Minimo de caracteres é 1")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "O Valor Minimo de caracteres é 4")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Perfil é obrigatório.")]
        public PerfilEnum? perfil { get; set; }
    }
}
