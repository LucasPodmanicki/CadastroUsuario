using System.ComponentModel.DataAnnotations;

namespace CadastroUsu.Models
{
    public class ContatoModel
    {

        // Criação visual na tabela
        public int Id { get; set; }

        [Required(ErrorMessage ="Nome do contato é obrigatório")]
        public string Name { get; set; }

        
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }


        //[Phone(ErrorMessage ="Celular inválido")]
        [Required(ErrorMessage ="Celular do Contato é obrigatório")]
        public string Celular { get; set; }    

    }
}
