using EF_Core_Demo.EF_Lib;
using EF_Core_Demo.EF_Lib.Models;
using EF_Core_Demo.Json_Lib;
using EF_Core_Demo.Models;
using Student = EF_Core_Demo.EF_Lib.Models.Student;


var students = StudentJson.Import();

var db = new Db();
db.CreateDb();

foreach (var student in students)
{
    db.Students.Add(new Student
    {
        Id = student.Id,
        FirstName = student.FirstName,
        LastName = student.LastName,
        DateOfBirth = student.DateOfBirth
    });

    foreach (var (subject, _) in student.Ratings)
    {
        foreach (var dbSubject in db.Subjects)
        {
            if (dbSubject.Name == subject ) continue;

            db.Subjects.Add(new Subject() { Name = subject});
        }
    }
}

