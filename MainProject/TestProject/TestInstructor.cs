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


    }
}