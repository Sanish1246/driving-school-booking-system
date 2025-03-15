using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MainProject.Context;

public class DrivingLessonBookingSystemContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        var root = builder.Build();

        optionsBuilder.UseSqlServer(root.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure(
                                                                                                        maxRetryCount: 10,
                                                                                                        maxRetryDelay: TimeSpan.FromSeconds(30),
                                                                                                        errorNumbersToAdd: null));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(s => s.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");
        modelBuilder.Entity<Instructor>().Property(i => i.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");
    }
}