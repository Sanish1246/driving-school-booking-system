using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MainProject.Models;
[Index(nameof(Email), IsUnique = true)]
public class Student
{
    // Primary Key
    [Key]
    public int StudentId { get; set; }
    
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    [MaxLength(254)]
    public required string Email { get; set; }
    
    [MaxLength(60)]
    public required string Password { get; set; }
    
    public required DateOnly DateOfBirth { get; set; }
    
    [MaxLength(15)]
    public required string PhoneNumber { get; set; }
    
    [MaxLength(100)]
    public required string Address { get; set; }
    
    // Navigation Properties
    // A Student can have many lessons
    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return $"First name: {FirstName}, Last name: {LastName}, Email: {Email}, Date of birth: {DateOfBirth}, Phone number: {PhoneNumber}, address: {Address}";
    }
}