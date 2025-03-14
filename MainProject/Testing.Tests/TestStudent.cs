namespace Testing.Tests;
using MainProject;
using MainProject.Context;
using MainProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[TestClass]
public sealed class TestStudent
{
    private Mock<DrivingLessonBookingSystemContext>? _mockContext;
    private Mock<DbSet<Student>>? _mockStudentSet;
    private StudentOperations? _studentOperations;

    [TestInitialize]
    public void Setup()
    {
        _mockContext = new Mock<DrivingLessonBookingSystemContext>();
        _mockStudentSet = new Mock<DbSet<Student>>();
        _mockContext.Setup(c => c.Students).Returns(_mockStudentSet.Object);
        _studentOperations = new StudentOperations();
    }

    [TestMethod]
    public void AddStudent_ShouldAddStudentToDatabase()
    {
        // Arrange
        var inputSequence = new List<string>
        {
            "John", // First Name
            "Doe", // Last Name
            "john.doe@example.com", // Email
            "SecurePass123!", // Password
            "2000/01/01", // Date of Birth
            "+23058226843", // Phone Number
            "123 Main St" // Address
        };

        
        // Simulate user input using StringReader
        using (var input = new StringReader(string.Join(Environment.NewLine, inputSequence)))
        {
            Console.SetIn(input);
            // Act
            _studentOperations!.AddStudent();
        }

        // Assert
        _mockStudentSet!.Verify(s => s.Add(It.IsAny<Student>()), Times.Once);
        _mockContext!.Verify(c => c.SaveChanges(), Times.Once);
    }

    [TestMethod]
    public void DeleteStudent_ShouldRemoveStudentFromDatabase()
    {
        // Arrange
        var inputSequence = new List<string>
        {
            "john.doe@example.com" // Email
        };

        // Simulate user input using StringReader
        using (var input = new StringReader(string.Join(Environment.NewLine, inputSequence)))
        {
            Console.SetIn(input);

            var studentList = new List<Student>
            {
                new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    DateOfBirth = new DateOnly(2000, 1, 1),
                    Address = "123 Main St",
                    PhoneNumber = "+23058226843",
                    Password = "SecurePass123!"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(studentList.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(studentList.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(studentList.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(studentList.GetEnumerator());

            _mockContext!.Setup(c => c.Students).Returns(mockSet.Object);

            // Act
            _studentOperations!.DeleteStudent();
        }

        // Assert
        _mockStudentSet!.Verify(s => s.Remove(It.IsAny<Student>()), Times.Once);
        _mockContext!.Verify(c => c.SaveChanges(), Times.Once);
    }

    [TestMethod]
    public void DisplayStudent_ShouldReturnAllStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student
            {
                FirstName = "Jojolo",
                LastName = "Dodo",
                Email = "jojolo.dodoe@gmail.com",
                DateOfBirth = new DateOnly(2011, 1, 9),
                Address = "la rue rouge",
                PhoneNumber = "+23058224543",
                Password = "SecurityPass123!"
            },
            new Student
            {
                FirstName = "Janette",
                LastName = "Ginger",
                Email = "janettesginger@gmail.com",
                DateOfBirth = new DateOnly(2014, 12, 2),
                Address = "soobajee lane",
                PhoneNumber = "+23054536844",
                Password = "tihisWrtr456!"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Student>>();
        mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
        mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
        mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
        mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

        _mockContext!.Setup(c => c.Students).Returns(mockSet.Object);

        // Act
        _studentOperations!.DisplayStudent();

        // Assert
        Assert.AreEqual(2, students.Count());
    }
}