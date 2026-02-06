using System.ComponentModel.DataAnnotations;

namespace Exercicio13ASP.Models
{
    public class Apresentacao
    {

    public int id { get; set; }
        [StringLength(50)]
    public string Pagina { get; set; }
    public string Texto { get; set; }
    }
}
