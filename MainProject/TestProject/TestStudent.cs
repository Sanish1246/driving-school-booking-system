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
    
        [TestMethod]
        public void AddUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase("SharedInMemoryDB")
                .Options;

            var input = new StringReader(string.Join('\n', new[]
            {
                "SampleUser",
                "SampleLastName",           
                "SampleUser@example.com",
                "StrongP@ssw0rd12",     
                "2010/01/01",         
                "+23059102030",
                "1st Address Test Road"
            }));
            Console.SetIn(input);

            var operation = new StudentOperations();

            // Act
            operation.AddUser();

            // Assert
            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                var student = context.Students.FirstOrDefault(s => s.Email == "SampleUser@example.com");
                Assert.IsNotNull(student);
                Assert.AreEqual("SampleUser", student!.FirstName);
                Assert.AreEqual("+23059102030", student.PhoneNumber);
            }
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase("SharedInMemoryDB")
                .Options;

            // Seed user
            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                var student = new Student
                {
                    FirstName = "FakeFirst",
                    LastName = "FakeLast",
                    Email = "Fakeuser@example.com",
                    Password = "Test12345!",
                    DateOfBirth = new DateOnly(2011, 02, 01),
                    Address = "Del Fake Road",
                    PhoneNumber = "+23051212211"
                };
                context.Students.Add(student);
                context.SaveChanges();
            }

            var input = new StringReader("Fakeuser@example.com\n");
            Console.SetIn(input);

            var operation = new StudentOperations();

            // Act
            operation.DeleteUser();

            // Assert
            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                var student = context.Students.FirstOrDefault(s => s.Email == "deleteuser@example.com");
                Assert.IsNull(student);
            }
        }
        
        [TestMethod]
        public void SearchUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>()
                .UseInMemoryDatabase("SharedInMemoryDB")
                .Options;

            using (var context = new DrivingLessonBookingSystemContext(options))
            {
                context.Students.Add(new Student
                {
                    FirstName = "Searchyy",
                    LastName = "McFindme",
                    Email = "searchme@example.com",
                    Password = "FindMe@123",
                    DateOfBirth = new DateOnly(2009, 06, 05),
                    Address = "123 Finder Street",
                    PhoneNumber = "+23051313232"
                });
                context.SaveChanges();
            }

            var input = new StringReader("searchme@example.com\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var operation = new StudentOperations();

            // Act
            operation.SearchUser();

            // Assert
            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("searchme@example.com"));
            Assert.IsTrue(consoleOutput.Contains("Searchyy"));
        }

        [TestMethod]
        public void DisplayUser()
        {
            // Arrange
            var output = new StringWriter();
            Console.SetOut(output);

            var operation = new StudentOperations();

            // Act
            operation.DisplayUser();

            // Assert
            var consoleOutput = output.ToString();
            
            Assert.IsTrue(consoleOutput.Contains("zoumounou@gmail.com"));
            Assert.IsTrue(consoleOutput.Contains("janettesginger@gmail.com"));
        }
    }
}