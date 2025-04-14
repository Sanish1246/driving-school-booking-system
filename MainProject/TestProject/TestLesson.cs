using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainProject;
using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TestProject
{
    [DoNotParallelize]
    [TestClass]
    public class TestLesson
    {
        private DrivingLessonBookingSystemContext _context;
        private const string InMemoryDbName = "SharedInMemoryDB";

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase(InMemoryDbName)
                .Options;

            _context = new DrivingLessonBookingSystemContext(options);

            _context.Lessons.RemoveRange(_context.Lessons);
            _context.Students.RemoveRange(_context.Students);
            _context.Instructors.RemoveRange(_context.Instructors);
            _context.Cars.RemoveRange(_context.Cars);
            _context.SaveChanges();

            var student = new Student
            {
                FirstName = "zouzou",
                LastName = "mounou",
                Email = "zoumounou@gmail.com",
                DateOfBirth = new DateOnly(2003, 04, 18),
                Address = "2 lalaland Main St",
                PhoneNumber = "+23058226843",
                Password = "ZouzouMounou123!"
            };

            var instructor = new Instructor
            {
                FirstName = "Mighty",
                LastName = "Quokka",
                Email = "quokka@sunnyisle.com",
                Password = "QuokkaRocks@22",
                DateOfBirth = new DateOnly(1990, 03, 15),
                PhoneNumber = "+2309990000",
                Address = "18 Hop Avenue"
            };

            var car = new Car
            {
                Make = "Toyota",
                Transmission = "Automatic",
                RegistrationNumber = "AB12 XYZ"
            };

            _context.Students.Add(student);
            _context.Instructors.Add(instructor);
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddLesson()
        {
            var lessonOps = new LessonOperations();

            var input = string.Join(Environment.NewLine,
                "zoumounou@gmail.com",
                "quokka@sunnyisle.com",
                "2025/04/20",
                "AB12 XYZ"
            );
            using var reader = new StringReader(input);
            Console.SetIn(reader);
            Console.SetOut(new StringWriter());

            lessonOps.AddLesson();

            var lesson = _context.Lessons
                .Include(l => l.Student)
                .Include(l => l.Instructor)
                .Include(l => l.Car)
                .FirstOrDefault();

            Assert.IsNotNull(lesson);
            Assert.AreEqual("zoumounou@gmail.com", lesson.Student.Email);
            Assert.AreEqual("quokka@sunnyisle.com", lesson.Instructor.Email);
            Assert.AreEqual("AB12 XYZ", lesson.Car.RegistrationNumber);
            Assert.AreEqual(new DateOnly(2025, 04, 20), lesson.Date);
        }

        // [TestMethod]
        // public void DeleteLesson()
        // {
        //     var student = _context.Students.First();
        //     var instructor = _context.Instructors.First();
        //     var car = _context.Cars.First();

        //     var lesson = new Lesson
        //     {
        //         StudentId = student.StudentId,
        //         InstructorId = instructor.InstructorId,
        //         CarId = car.CarId,
        //         Date = DateOnly.FromDateTime(DateTime.Today)
        //     };

        //     _context.Lessons.Add(lesson);
        //     _context.SaveChanges();

        //     var input = string.Join(Environment.NewLine,
        //         lesson.Date.ToString("yyyy/MM/dd"),
        //         lesson.LessonId.ToString()
        //     );
            
        //     Console.SetIn(new StringReader(input));
        //     Console.SetOut(new StringWriter());

        //     var lessonOps = new LessonOperations();
        //     lessonOps.DeleteLesson();

        //     var deletedLesson = _context.Lessons.Find(lesson.LessonId);

        //     Assert.IsNull(deletedLesson);
        // }

        [TestMethod]
        public void SearchDate()
        {
            var student = _context.Students.First();
            var instructor = _context.Instructors.First();
            var car = _context.Cars.First();

            var date = new DateOnly(2025, 04, 20);

            var lesson = new Lesson
            {
                StudentId = student.StudentId,
                InstructorId = instructor.InstructorId,
                CarId = car.CarId,
                Date = date
            };

            _context.Lessons.Add(lesson);
            _context.SaveChanges();

            var input = date.ToString("yyyy/MM/dd");
            Console.SetIn(new StringReader(input));
            var writer = new StringWriter();
            Console.SetOut(writer);

            var lessonOps = new LessonOperations();
            lessonOps.SearchDate();

            var output = writer.ToString();
            Assert.IsTrue(output.Contains(student.Email));
            Assert.IsTrue(output.Contains(instructor.Email));
        }

        [TestMethod]
        public void Test_EnterDate_ValidDate()
        {
            // Arrange
            var input = "2025/04/20";
            Console.SetIn(new StringReader(input));
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var result = LessonOperations.EnterDate();

            // Assert
            Assert.AreEqual(new DateOnly(2025, 04, 20), result);
        }

        [TestMethod]
        public void Test_EnterDate_InvalidThenValidDate()
        {
            // Arrange
            var input = new StringReader(string.Join(Environment.NewLine,
                "wrongdate",
                "",
                "2025/04/20"
            ));
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var result = LessonOperations.EnterDate();

            // Assert
            Assert.AreEqual(new DateOnly(2025, 04, 20), result);
        }


    }
}
