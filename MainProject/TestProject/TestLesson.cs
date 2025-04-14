using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainProject;
using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

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

            // Clear existing data
            _context.Lessons.RemoveRange(_context.Lessons);
            _context.Students.RemoveRange(_context.Students);
            _context.Instructors.RemoveRange(_context.Instructors);
            _context.Cars.RemoveRange(_context.Cars);
            _context.SaveChanges();

            // Seed data
            _context.Students.Add(new Student
            {
                FirstName = "zouzou",
                LastName = "mounou",
                Email = "zoumounou@gmail.com",
                DateOfBirth = new DateOnly(2003, 04, 18),
                Address = "2 lalaland Main St",
                PhoneNumber = "+23058226843",
                Password = "ZouzouMounou123!"
            });

            _context.Instructors.Add(new Instructor
            {
                InstructorId = 10,
                FirstName = "Mighty",
                LastName = "Quokka",
                Email = "quokka@sunnyisle.com",
                Password = "QuokkaRocks@22",
                DateOfBirth = new DateOnly(1990, 03, 15),
                PhoneNumber = "+2309990000",
                Address = "18 Hop Avenue"
            });

            _context.Cars.Add(new Car
            {
                Make = "Toyota",
                Transmission = "Automatic",
                RegistrationNumber = "AB12 XYZ"
            });

            _context.SaveChanges();
        }

        [TestMethod]
        public void AddLesson()
        {
            // Arrange
            var lessonOps = new LessonOperations();
            var input = string.Join(Environment.NewLine,
                "zoumounou@gmail.com",     
                "quokka@sunnyisle.com",    
                "2025/04/20",
                "AB12 XYZ"
            );
            using var reader = new StringReader(input);
            Console.SetIn(reader);

            using var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            lessonOps.AddLesson();

            // Assert
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


    }
}
