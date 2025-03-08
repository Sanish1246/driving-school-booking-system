namespace MainProject.Models;

public class Lesson
{
    // Primary Key
    public int LessonId { get; set; }
    
    // Foreign keys
    public int InstructorId { get; set; }
    public int StudentId { get; set; }
    public int VehicleId { get; set; }
    
    // Navigation Properties
    // A lesson can only be taught by one instructor at a time
    public Instructor? Instructor { get; set; }
    // A lesson can only be taught in a particular car at a time
    public Car? Car { get; set; }
    // A lesson can only be assigned to a particular student at a time
    public Student? Student { get; set; }

    public override string ToString()
    {
        return $"This lesson is associated with student {Student} along with instructor {Instructor} and car {Car}";
    }
}