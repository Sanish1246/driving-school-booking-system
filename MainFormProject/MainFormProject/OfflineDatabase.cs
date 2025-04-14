using MainFormProject.Models;
using MainFormProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainFormProject;

// load each table in a hash map and perform operations

public class OfflineDatabase
{
    public HashMap<string, Instructor> InstructorTable { get; } = new HashMap<string, Instructor>();
    public HashMap<string, Student> StudentTable { get; } = new HashMap<string, Student>();
    public HashMap<int, Lesson> LessonTable { get; } = new HashMap<int, Lesson>();
    public HashMap<string, Car> CarTable { get; } = new HashMap<string, Car>();
    
    public  void LoadTables()
    {

        using (var context = new DrivingLessonBookingSystemContext())
        {
            // Loading instructor table in HashTable
            var instructors = context.Instructors.Include(l => l.Lessons);
            foreach (var instructor in instructors)
            {
                InstructorTable.Insert(instructor.Email,instructor);
            }
    
            // Loading student table in HashTable
            var students = context.Students.Include(l => l.Lessons);
            foreach (var student in students)
            {
                StudentTable.Insert(student.Email,student);
            }
    
            // Loading car table in HashTable
            var cars = context.Cars.Include(l => l.Lessons);
            foreach (var car in cars)
            {
                CarTable.Insert(car.RegistrationNumber, car);
            }
    
            // Loading car table in HashTable
            var lessons = context.Lessons
                .Include(l => l.Instructor)
                .Include(l => l.Car)
                .Include(l => l.Student);
    
            foreach (var lesson in lessons)
            {
                LessonTable.Insert(lesson.LessonId, lesson);
            }
    
        }
    }
}