using EF_Core_Demo.EF_Lib;
using EF_Core_Demo.EF_Lib.Models;
using EF_Core_Demo.Json_Lib;
using Microsoft.EntityFrameworkCore;
using Student = EF_Core_Demo.EF_Lib.Models.Student;


var students = StudentJson.Import();

var tableStudents = new List<Student>();
var tableSubjects = new List<Subject>();
var tableStudentsRatings = new List<StudentsRating>();

foreach (var student in students)
{
    tableStudents.Add(new Student
    {
        FirstName = student.FirstName,
        LastName = student.LastName,
        DateOfBirth = student.DateOfBirth
    });

    foreach (var (subject, _) in student.Ratings)
    {
        if (tableSubjects.Count == 0)
        {
            tableSubjects.Add(new Subject { Name = subject });
        }

        var findSubject = tableSubjects.FirstOrDefault(s => s.Name == subject);
        if (findSubject == null)
        {
            tableSubjects.Add(new Subject { Name = subject });
        }
    }

    foreach (var (subject, marks) in student.Ratings)
    {
        var _student = tableStudents.First(s => s.LastName == student.LastName && s.FirstName == student.FirstName && s.DateOfBirth == student.DateOfBirth);
        var _subject = tableSubjects.First(s => s.Name == subject);

        foreach (var mark in marks)
        {
            tableStudentsRatings.Add(new StudentsRating
            {
                Student = _student,
                Subject = _subject,
                Mark = mark
            });
        }
    }
}

var db = new Db();
db.CreateDb();
db.Students.AddRange(tableStudents);
db.Subjects.AddRange(tableSubjects);
db.StudentsRatings.AddRange(tableStudentsRatings);
db.SaveChanges();
