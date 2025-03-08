namespace MainProject.Models;

public class Student
{
    // Primary Key
    public int StudentId { get; set; }
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    
    // Navigation Properties
    // A Student can have many lessons
    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return $"First name: {FirstName}, Last name: {LastName}, Email: {Email}, Date of birth: {DateOfBirth}, Phone number: {PhoneNumber}, address: {Address}";
    }
}