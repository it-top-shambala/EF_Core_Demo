using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_Demo.EF_Lib.Models;

[Table("table_subjects")]
public class Subject
{
    [Column("subject_id")]
    public int Id { get; set; }
    [Column("subject_name")]
    public string Name { get; set; }

    public IEnumerable<StudentsRating> StudentsRatings { get; set; } = new List<StudentsRating>();
}
