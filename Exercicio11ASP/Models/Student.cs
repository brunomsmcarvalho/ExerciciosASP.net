namespace Exercicio11ASP.Models
{
 public class Student
    {
        // Propriedade de chave primária
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // Relacionamento um - para - muitos com Enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

