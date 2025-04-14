using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MainProject.Context;
using MainProject.Models;
using MainProject;
using System;
using System.IO;
using System.Linq;

namespace TestProject
{
    [DoNotParallelize]
    [TestClass]
    public class TestInstructor
    {
        private const string InMemoryDbName = "SharedInMemoryDB";

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase(InMemoryDbName)
                .Options;

            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                context.Instructors.Add(new Instructor
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

                context.Students.Add(new Student
                {
                    FirstName = "Learna",
                    LastName = "Triber",
                    Email = "learna@trymail.com",
                    Password = "StudentPass@1",
                    DateOfBirth = new DateOnly(2004, 12, 10),
                    Address = "789 Academy Rd",
                    PhoneNumber = "+2308884444"
                });

                context.Cars.Add(new Car
                {
                    CarId = 1,
                    Make = "Toyota",
                    RegistrationNumber = "juju1234",
                    Transmission = "Manual"
                });

                context.Lessons.Add(new Lesson
                {
                    LessonId = 1,
                    Date = DateOnly.FromDateTime(DateTime.Today),
                    CarId = 1,
                    InstructorId = 10
                });

                context.SaveChanges();
            }
        }

        [TestMethod]
        public void AddEntity()
        {
            // Arrange
            var input = new StringReader(string.Join('\n', new[]
            {
                "Eloise",
                "Vanderfox",                 
                "eloise.fox@tutorsden.com",
                "FoxySecurePass12!",         
                "1992/04/25",
                "+2307771122",
                "14 Burrow Lane"
            }));
            Console.SetIn(input);

            var operation = new InstructorOperations();

            // Act
            operation.AddEntity();

            // Assert
            using var context = new DrivingLessonBookingSystemContext(
                new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                    .UseInMemoryDatabase(InMemoryDbName)
                    .Options);

            var instructor = context.Instructors.FirstOrDefault(i => i.Email == "eloise.fox@tutorsden.com");

            Assert.IsNotNull(instructor);
            Assert.AreEqual("Eloise", instructor.FirstName);
            Assert.AreEqual("+2307771122", instructor.PhoneNumber);
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            var input = new StringReader("quokka@sunnyisle.com\n");
            Console.SetIn(input);

            var operation = new InstructorOperations();

            // Act
            operation.DeleteUser();

            // Assert
            using var context = new DrivingLessonBookingSystemContext(
                new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                    .UseInMemoryDatabase(InMemoryDbName)
                    .Options);

            var instructor = context.Instructors.FirstOrDefault(i => i.Email == "quokka@sunnyisle.com");
            Assert.IsNull(instructor);
        }

    }
}