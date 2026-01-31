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
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        public string Email { get; set; }

        //Idade
        [Display(Name = "Idade", Description = "A idade deve estar entre 15 e 100 anos.")]
        [Range(15, 100)]
        public int Idade { get; set; }

        // Data de Nascimento
        [Display(Name = "Data de Nascimento", Description = "Informe a data de nascimento.")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        // Curso
        [Display(Name = "Curso", Description = "Informe o curso que está matriculado.")]
        [StringLength(100, ErrorMessage = "O campo curso não pode ter mais que 100 caracteres.")]
        public string Curso { get; set; } // Novo parâmetro
    }
}
