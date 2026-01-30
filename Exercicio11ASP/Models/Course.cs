using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio11ASP.Models
{
    public class Course
    {
        // Especifica que o valor de CourseID não será gerado pelo banco de dados
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public string? Description { get; set; }

        // Relacionamento um - para - muitos com Enrollments
        // Inicializa a coleção para evitar referências nulas
        // Uma disciplina pode ter muitas matrículas
        public ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
    }
}
