namespace MainProject.Models;

public class Car
{
    public int CarId { get; set; }
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string RegistrationNumber { get; set; } = null!;
    
    // Navigation Properties
    // A car can be used for many lessons
    public ICollection<Lesson> Lessons { get; } = new List<Lesson>();

    public override string ToString()
    {
        return $"Make of car is: {Make}, model of car is {Model} and registration number is {RegistrationNumber}";
    }
}