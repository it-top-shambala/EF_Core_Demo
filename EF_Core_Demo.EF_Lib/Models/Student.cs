using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Demo.EF_Lib.Models;

[Table("table_students")]
public class Student
{
    [Column("student_id")]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("last_name")]
    public string LastName { get; set; }
    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    public IEnumerable<StudentsRating> StudentsRatings { get; set; } = new List<StudentsRating>();
}
