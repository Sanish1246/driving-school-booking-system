using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MainProject.Context;

public class DrivingLessonBookingSystemContext : DbContext
{
    public virtual DbSet<Instructor> Instructors { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Car> Cars { get; set; }
    private const string InMemoryDbName = "SharedInMemoryDB";
    public DrivingLessonBookingSystemContext()
    {
    }

    public DrivingLessonBookingSystemContext(DbContextOptions<DrivingLessonBookingSystemContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Only configure if not already configured (in-memory database for tests)
        if (!optionsBuilder.IsConfigured)
        {
            // If not running tests, use SQL Server
            if (!IsRunningTests())
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var config = builder.Build();
                var connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlServer(connectionString, options =>
                {
                    options.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });

                // Log only if NOT running tests
                var logPath = GetPath();
                Directory.CreateDirectory(Path.GetDirectoryName(logPath));
                var logStream = new StreamWriter(logPath, append: true);

                optionsBuilder
                    .ConfigureWarnings(warnings => warnings
                        .Log((RelationalEventId.ConnectionOpened, LogLevel.Information),
                            (RelationalEventId.ConnectionClosed, LogLevel.Information)))
                    .LogTo(logStream.WriteLine,
                        LogLevel.Information,
                        DbContextLoggerOptions.DefaultWithLocalTime | DbContextLoggerOptions.SingleLine);
            }
            else
            {
                // Use In-Memory Database for tests
                optionsBuilder.UseInMemoryDatabase(databaseName: InMemoryDbName);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(s => s.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");

        modelBuilder.Entity<Instructor>().Property(i => i.Email)
            .UseCollation("SQL_Latin1_General_CP1_CI_AI");
    }

    private static string GetPath()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        return Path.Combine(projectDirectory, "Logs", "logs.txt");
    }

    private static bool IsRunningTests()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .Any(assembly => assembly.FullName.StartsWith("xunit") ||
                             assembly.FullName.StartsWith("nunit") ||
                             assembly.FullName.StartsWith("Microsoft.VisualStudio.TestPlatform"));
    }
}