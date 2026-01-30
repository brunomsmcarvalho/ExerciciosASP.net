namespace Exercicio11ASP.Models;
 public enum Grade
{
    A, B, C, D, F
}
public class Enrollment
{
    public int EnrollmentID { get; set; } // Propriedade de chave primária
    public Grade? Grade { get; set; } // Propriedade de enumeração Grade (pode ser nula)

    public int CourseID { get; set; } // Propriedade de chave estrangeira necessária
    public Course Course { get; set; } // Relacionamento um - para - um com Course 
    public int StudentID { get; set; } // Propriedade de chave estrangeira necessária
    public Student Student { get; set; } // Relacionamento um - para - um com Student

}

