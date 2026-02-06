using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Exercicio13ASP.Models
{
    public class Segmentos
    {

    public int Id { get; set; }

        [StringLength(100)]
        [DisplayName ("Segmento")]
    public String SegmentoNome { get; set; }

    public String Descricao { get; set; }

    //Relacionamento um-para-um com Apresentacao
    //Relacionamento um-para-muitos com Destinos 
    public ICollection<Destinos> Destinos { get; set; } = new List<Destinos>();
    }
}
