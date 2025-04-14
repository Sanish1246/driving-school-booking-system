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

        [TestMethod]
        public void CheckEmailExistence_ReturnsTrueForExistingEmail()
        {
            string email = "zoumounou@gmail.com";
            bool exists = StudentOperations.CheckEmailExistence(email);
            Assert.IsTrue(exists);
        }

        [TestMethod]
        public void CheckEmailExistence_ReturnsFalseForNonExistingEmail()
        {
            string email = "nonexistent@example.com";
            bool exists = StudentOperations.CheckEmailExistence(email);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void EnterPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange
            var email = "zoumounou@gmail.com";
            var input = "ZouzouMounou123!\n";
            Console.SetIn(new StringReader(input));

            // Act
            bool result = StudentOperations.EnterPassword(email);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EnterPassword_WrongPassword_ReturnsFalse()
        {
            // Arrange
            var email = "zoumounou@gmail.com";
            var input = "wrongpassword\n";
            Console.SetIn(new StringReader(input));

            // Act
            bool result = StudentOperations.EnterPassword(email);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EnterEmail_ValidAndExistingEmail_ReturnsEmail()
        {
            // Arrange
            var expectedEmail = "zoumounou@gmail.com";
            var input = $"{expectedEmail}\n";
            Console.SetIn(new StringReader(input));

            // Act
            var result = StudentOperations.EnterEmail();

            // Assert
            Assert.AreEqual(expectedEmail, result);
        }
        
       [TestMethod]
        public void EnterEmail_InvalidThenValidInput_ReturnsValidEmail()
        {
            // Arrange 
            var invalidEmail = "wrong-format";
            var validEmail = "janettesginger@gmail.com";
            var input = $"{invalidEmail}\n{validEmail}\n";
            Console.SetIn(new StringReader(input));

            // Act
            var result = StudentOperations.EnterEmail();

            // Assert
            Assert.AreEqual(validEmail, result);
        }

        [TestMethod]
        public void EnterEmail_NonExistingThenValidInput_ReturnsValidEmail()
        {
            // Arrange
            var nonExistent = "ghost@example.com";
            var valid = "janettesginger@gmail.com";
            var input = $"{nonExistent}\n{valid}\n";
            Console.SetIn(new StringReader(input));

            // Act
            var result = StudentOperations.EnterEmail();

            // Assert
            Assert.AreEqual(valid, result);
        }
    
    }
}