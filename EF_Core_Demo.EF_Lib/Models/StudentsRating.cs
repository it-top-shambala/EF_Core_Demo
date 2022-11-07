using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Demo.EF_Lib.Models;

[Table("table_students_ratings")]
public class StudentsRating
{
    [Column("students_rating_id")]
    public int Id { get; set; }

    [Column("student_id")]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [Column("subject_id")]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    [Column("mark")]
    public int Mark { get; set; }
}
