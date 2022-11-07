﻿namespace EF_Core_Demo.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Dictionary<string, List<int>> Ratings { get; set; }
}
