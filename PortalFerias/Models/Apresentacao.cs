using System.ComponentModel.DataAnnotations;

namespace PortalFerias.Models
{
    public class Apresentacao_BC
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Pagina { get; set; }

        public string? Texto { get; set; }
    }
}
