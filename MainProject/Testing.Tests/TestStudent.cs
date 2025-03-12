namespace Testing.Tests;
using MainProject;
using MainProject.Context;
using MainProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[TestClass]
public sealed class TestStudent
{
    private Mock<DrivingLessonBookingSystemContext> _mockContext;
    private Mock<DbSet<Student>> _mockStudentSet;
    private StudentOperations _studentOperations;

    [TestInitialize] // Runs before each test to initialize dependencies
    public void Setup()
    {
        _mockContext = new Mock<DrivingLessonBookingSystemContext>();
        _mockStudentSet = new Mock<DbSet<Student>>();
        _mockContext.Setup(c => c.Students).Returns(_mockStudentSet.Object);
        _studentOperations = new StudentOperations(_mockContext.Object);
    }

    [TestMethod] // Ensures a student is added successfully
    public void AddStudent_ShouldAddStudentToDatabase()
    {
        // Arrange
        var student = new Student
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            DateOfBirth = new DateOnly(2000, 1, 1),
            Address = "123 Main St",
            PhoneNumber = "+23058226843",
            Password = "SecurePass123"
        };
        
        // Act
        _studentOperations.AddStudent(student);
        
        // Assert
        _mockStudentSet.Verify(s => s.Add(It.IsAny<Student>()), Times.Once);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);
    }

    [TestMethod] // Ensures a student is deleted correctly
    public void DeleteStudent_ShouldRemoveStudentFromDatabase()
    {
        // Arrange
        var studentEmail = "john.doe@example.com";
        var studentList = new List<Student>
        {
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Email = studentEmail,
                DateOfBirth = new DateOnly(2000, 1, 1),
                Address = "123 Main St",
                PhoneNumber = "+23058226843",
                Password = "SecurePass123"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Student>>();
        mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(studentList.Provider);
        mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(studentList.Expression);
        mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(studentList.ElementType);
        mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(studentList.GetEnumerator());

        _mockContext.Setup(c => c.Students).Returns(mockSet.Object);

        // Act
        _studentOperations.DeleteStudent(studentEmail);

        // Assert
        mockSet.Verify(s => s.Remove(It.IsAny<Student>()), Times.Once);
        _mockContext.Verify(c => c.SaveChanges(), Times.Once);
    }

    [TestMethod] // Ensures student list is retrieved correctly
    public void DisplayStudent_ShouldReturnAllStudents()
    {
        // Arrange
        var students = new List<Student>
        {
            new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Address = "123 Main St",
                PhoneNumber = "+23058226843",
                Password = "SecurePass123"
            },
            new Student
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateOnly(2001, 2, 2),
                Address = "456 Side St",
                PhoneNumber = "+23058226844",
                Password = "AnotherPass456"
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Student>>();
        mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
        mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
        mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
        mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

        _mockContext.Setup(c => c.Students).Returns(mockSet.Object);

        // Act
        var result = _studentOperations.DisplayStudent();

        // Assert
        Assert.AreEqual(2, result.Count);
    }
}
