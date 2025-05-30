﻿using MainFormProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MainFormProject.Context;

public class DrivingLessonBookingSystemContext : DbContext
{
    // Entities present in database
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    // Log database operations to file
    private readonly StreamWriter _logStream = new StreamWriter(new FileStream(
            GetPath(),
            FileMode.Append,
            FileAccess.Write,
            FileShare.ReadWrite   // Allow others to read/write at same time
        ));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connect with database
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        var root = builder.Build();

        optionsBuilder.UseSqlServer(root.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure(
                                                                                                        maxRetryCount: 10,
                                                                                                        maxRetryDelay: TimeSpan.FromSeconds(30),
                                                                                                        errorNumbersToAdd: null))
            .ConfigureWarnings(
                b => b.Log(
                    (RelationalEventId.ConnectionOpened, LogLevel.Information),
                    (RelationalEventId.ConnectionClosed, LogLevel.Information)))
            .LogTo(_logStream.WriteLine, LogLevel.Information, DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Search and comparison are case and accent insensitive
        modelBuilder.Entity<Student>().Property(s => s.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");
        modelBuilder.Entity<Instructor>().Property(i => i.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");
    }

    public override void Dispose()
    {
        base.Dispose();
        _logStream.Dispose();
    }

    private static string GetPath()
    {
        // Get working directory full path
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        return (Path.Combine(projectDirectory, "Logs", "logs.txt"));
    }

}