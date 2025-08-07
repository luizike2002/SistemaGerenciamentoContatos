using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    [Table("Login")]
    public class LoginModel
    {
        [Required(ErrorMessage = "O Login é Obrigatório")]
        public string Login { get; set; }


        [Required(ErrorMessage = "A Senha é Obrigatória")]
        public string Senha { get; set; }
    }
}
