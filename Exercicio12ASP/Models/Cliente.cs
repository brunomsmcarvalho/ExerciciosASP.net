using System.ComponentModel.DataAnnotations;

namespace Exercicio12ASP.Models
{
    public class Cliente
    {
        //
        // prop tab tab - > criar propriedade automaticamente
        //
        public int Id { get; set; }
        // Nome
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string? Nome { get; set; }
        // Morada
        [Display(Name = "Morada Cliente", Description = "Morada do Cliente.")]
        public string? Morada { get; set; }
        // Email
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = " O Email deve ter no mínimo 5 e no máximo 100 caracteres. ")]
        public string? Email { get; set; }
    }

}
