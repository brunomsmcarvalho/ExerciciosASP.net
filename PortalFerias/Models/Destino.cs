using System.ComponentModel.DataAnnotations;

namespace PortalFerias.Models
{
    public class Destino_BC
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage ="O Pais deve conter mais que 3 caracteres!!")]
        public string? Pais { get; set; }

        [DisplayFormat(DataFormatString = "{0:C1}")]
        public decimal Preco { get; set; }
    }
}
