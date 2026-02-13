using System.ComponentModel.DataAnnotations;

namespace Exercicio14ASP.Models
{
    public class Conteudo
    {
        // prop tab tab -> cria a prop
        // public int MyProperty { get; set; }
        public int Id { get; set; }
        [StringLength(50)]
        public string Pagina { get; set; }
        [StringLength(50)]
        public string Titulo { get; set; }
        public string Texto { get; set; }
        [StringLength(50)]
        public string Autor { get; set; }
        public DateTime Data { get; set; }
    }

}
