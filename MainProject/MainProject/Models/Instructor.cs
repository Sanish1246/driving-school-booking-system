using System.ComponentModel.DataAnnotations;
namespace MainProject.Models;

public class Instructor
{
    // Primary Key
    [Key]
    public int InstructorId { get; set; }
    
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    [MaxLength(15)]
    public required string PhoneNumber { get; set; }
    
    // Navigation properties
    // An instructor can teach many lessons

    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return
            $"First name: {FirstName}, Last name: {LastName}, Phone number: {PhoneNumber}";
    }
}