namespace MainProject.Models;

public class Instructor
{
    // Primary Key
    public int InstructorId { get; set; }
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    
    // Navigation properties
    // An instructor can teach many lessons

    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return
            $"First name: {FirstName}, Last name: {LastName}, Phone number: {PhoneNumber}";
    }
}