using System.ComponentModel.DataAnnotations;
namespace MainProject.Models;

public class Car
{
    // Primary key
    [Key]
    public int CarId { get; set; }
    
    [MaxLength(20)]
    public required string Make { get; set; }
    
    [MaxLength(20)]
    public required string Transmission { get; set; }
    
    [MaxLength(20)]
    public required string RegistrationNumber { get; set; }
    
    // Navigation Properties
    // A car can be used for many lessons
    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return $"Make: {Make}, Transmission of car: {Transmission} and Registration number: {RegistrationNumber}";
    }
}