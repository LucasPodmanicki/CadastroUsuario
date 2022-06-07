using System.ComponentModel.DataAnnotations;

namespace CadastroUsu.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Login Obrigatório!")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Email Obrigatório!")]
        public string Email { get; set; }

    }
}
