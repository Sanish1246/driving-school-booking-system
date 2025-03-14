using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MainProject.Context;

public class DrivingLessonBookingSystemContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public DbSet<Car> Cars { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
        var root = builder.Build();

        optionsBuilder.UseSqlServer(root.GetConnectionString("DefaultConnection"));
    }
}