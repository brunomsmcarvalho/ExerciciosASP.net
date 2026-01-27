using System.ComponentModel.DataAnnotations;
namespace Exercicio9ASP.Models
{
    public class Aluno
    {
        // Id
        public int Id { get; set; }

        //Nome
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome { get; set; }

        //Email
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }

        //Idade
        [Display(Name = "Idade", Description = "A idade deve estar entre 15 e 100 anos.")]
        [Range(15, 100)]
        public int Idade { get; set; }
    }
}