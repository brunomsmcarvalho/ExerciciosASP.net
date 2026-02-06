using System.ComponentModel.DataAnnotations;

namespace Exercicio13ASP.Models
{
    public class Destinos
    {
        public int Id { get; set; }

        [StringLength(100)]
        public String Nome { get; set; }
        public String Descricao { get; set; }

        [StringLength(50)]
        public String Regiao { get; set; }
        //Chave estrangeira para Segmentos
        [Display(Name = "Segmento")]
        public int SegmentosId { get; set; }
        //Relacionamento muitos-para-um com Segmentos
        public Segmentos Segmentos { get; set; }
    }
}
