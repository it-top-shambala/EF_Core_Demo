﻿using DbConfigLib;
using EF_Core_Demo.EF_Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Demo.EF_Lib;

public class Db : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentsRating> StudentsRatings { get; set; }

    public Db() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(DbConfig.ImportFromJson().ToString());
    }

    public void CreateDb()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}
