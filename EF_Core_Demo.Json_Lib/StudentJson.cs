using System.Text.Json;
using EF_Core_Demo.Models;

namespace EF_Core_Demo.Json_Lib;

public static class StudentJson
{
    public static void Export(IEnumerable<Student> students, string path = "student.json")
    {
        var json = JsonSerializer.Serialize(students);
        File.WriteAllText(path, json);
    }

    public static IEnumerable<Student>? Import(string path = "student.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<IEnumerable<Student>>(json);
    }
}
