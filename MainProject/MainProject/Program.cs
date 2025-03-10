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
﻿
bool successRegister = false;
int choice = 0;
string username;
string password;

Console.WriteLine("Welcome to the driving lesson booking system!");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("1.Login");
Console.WriteLine("2. Registration");
Console.WriteLine("3. Exit");
Console.WriteLine("Hello, World!");

while (choice != 1 || choice != 2 || choice !=3)
{
    Console.Write("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.Clear();
        break;
    }
    else if (choice == 2)
    {
        do
        {
            Console.Clear();
            Console.Write("Enter a username: ");
            username = Console.ReadLine();

            Console.Write("Enter a password: ");
            password = Console.ReadLine();

            successRegister = RegisterUser(username, password);
            if (!successRegister)
            {
                Console.ReadLine();
            }
            } while (!successRegister);
        
        break;
    }
    else if (choice == 3)
    {
        Console.Clear();
        Console.WriteLine("Press enter to exit");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice! Re-input");
    }
}

Console.ReadKey();

static bool ValidatePassword(string password)
{
    if (password.Length < 8 || password.ToUpper() == password || password.ToLower() == password)
    {
        Console.WriteLine("Invalid password! It must have at least 8 charcters, at least 1 upper case letter and at least a lower case letter");
        return false;
    }
    return true;
}

static bool ValidateUserName(string username)
{
    if (username.Length < 8 || username.Length>20)
    {
        Console.WriteLine("Invalid username! It must be between 8 and 20 characters");
        return false;
    }
    return true;
}


static bool RegisterUser(string username, string password)
{
    return ValidatePassword(password) && ValidateUserName(username);
}


