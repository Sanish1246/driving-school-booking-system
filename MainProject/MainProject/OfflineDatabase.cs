using MainProject.Models;
using MainProject.Context;
using Microsoft.EntityFrameworkCore;

namespace MainProject;

// load each table in a hash map and perform operations

public class OfflineDatabase
{
    public HashMap<int, Instructor> InstructorTable { get; } = new HashMap<int, Instructor>();
    public HashMap<int, Student> StudentTable { get; } = new HashMap<int, Student>();
    public HashMap<int, Lesson> LessonTable { get; } = new HashMap<int, Lesson>();
    public HashMap<int, Car> CarTable { get; } = new HashMap<int, Car>();
    
    public  void LoadTables()
    {

        using (var context = new DrivingLessonBookingSystemContext())
        {
            // Loading instructor table in HashTable
            var instructors = context.Instructors.Include(l => l.Lessons);
            foreach (var instructor in instructors)
            {
                InstructorTable.Insert(instructor.InstructorId,instructor);
            }
    
            // Loading student table in HashTable
            var students = context.Students.Include(l => l.Lessons);
            foreach (var student in students)
            {
                StudentTable.Insert(student.StudentId,student);
            }
    
            // Loading car table in HashTable
            var cars = context.Cars.Include(l => l.Lessons);
            foreach (var car in cars)
            {
                CarTable.Insert(car.CarId, car);
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