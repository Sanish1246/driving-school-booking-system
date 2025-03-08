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
        return $"First name of the student is: {FirstName}, last name is: {LastName}, email is: {Email}, date of birth is: {DateOfBirth}, phone number is: {PhoneNumber} and address is: {Address}";
    }
}