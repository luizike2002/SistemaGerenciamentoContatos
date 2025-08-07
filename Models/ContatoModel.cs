using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    [Table("Contato")]
    public class ContatoModel
    {
        [Key]
        public int ContatoId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 5,ErrorMessage = "O Campo deve conter no mínimo 5 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 9, ErrorMessage = "O Campo deve conter no mínimo 9 caracteres")]
        [Display(Name = "Email do Contato")]


        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Phone(ErrorMessage ="O Formato é de Telefone Incorreto")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone do Contato")]
        public string Telefone { get; set; }

        public int? UsuarioId { get; set; }
        [BindNever]              
        [ValidateNever]
        public UsuarioModel Usuario { get; set; }
    }
}
