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

    // Constructor for dependency injection
    public DrivingLessonBookingSystemContext(DbContextOptions<DrivingLessonBookingSystemContext> options) : base(options)
    {
    }

    // Default constructor for normal database usage
    public DrivingLessonBookingSystemContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) // Only configure if options are not already provided (for testing)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            var root = builder.Build();
            optionsBuilder.UseSqlServer(root.GetConnectionString("DefaultConnection"));
        }
    }
}