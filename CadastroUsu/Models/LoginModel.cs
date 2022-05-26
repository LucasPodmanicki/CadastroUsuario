using System.ComponentModel.DataAnnotations;

namespace CadastroUsu.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage ="Login Obrigatório!")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Senha Obrigatório!")]
        public string Senha { get; set; }  

    }
}
