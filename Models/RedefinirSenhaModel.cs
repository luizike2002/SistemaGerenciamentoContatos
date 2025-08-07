using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    [Table("Login")]
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Digite o Email")]
        public string Email { get; set; }
    }
}
