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
    public class TestStudent
    {
        private const string InMemoryDbName = "SharedInMemoryDB";

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase(databaseName: InMemoryDbName)
                .Options;

            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                context.Students.Add(new Student
                {
                    FirstName = "zouzou", LastName = "mounou", Email = "zoumounou@gmail.com",
                    DateOfBirth = new DateOnly(2003, 04, 18), Address = "2 lalaland Main St",
                    PhoneNumber = "+23058226843", Password = "ZouzouMounou123!",
                });

                context.Students.Add(new Student
                {
                    FirstName = "Janette", LastName = "Ginger", Email = "janettesginger@gmail.com",
                    DateOfBirth = new DateOnly(2014, 12, 2), Address = "soobajee lane",
                    PhoneNumber = "+23054536844", Password = "tihisWrtr456!" 
                });

                context.SaveChanges();
            }
        }


    }
}