// load each table in a hash map and perform operations

using MainProject.Models;
using MainProject.Context;
using Microsoft.EntityFrameworkCore;

var instructorTable = new HashMap<int, Instructor>();
var studentTable = new HashMap<int, Student>();
var lessonTable = new HashMap<int, Lesson>();
var carTable = new HashMap<int, Car>();

using (var context = new DrivingLessonBookingSystemContext())
{
    // Loading instructor table in HashTable
    var instructors = context.Instructors.Include(l => l.Lessons);
    foreach (var instructor in instructors)
    {
        instructorTable.Insert(instructor.InstructorId,instructor);
    }
    
    // Loading student table in HashTable
    var students = context.Students.Include(l => l.Lessons);
    foreach (var student in students)
    {
        studentTable.Insert(student.StudentId,student);
    }
    
    // Loading car table in HashTable
    var cars = context.Cars.Include(l => l.Lessons);
    foreach (var car in cars)
    {
        carTable.Insert(car.CarId, car);
    }
    
    // Loading car table in HashTable
    var lessons = context.Lessons
        .Include(l => l.Instructor)
        .Include(l => l.Car)
        .Include(l => l.Student);
    
    foreach (var lesson in lessons)
    {
        lessonTable.Insert(lesson.LessonId, lesson);
    }
    
}

