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
[DoNotParallelize] //disable parallel execution to prevent conflicts
public sealed class TestStudent
{
    private Mock<DrivingLessonBookingSystemContext>? _mockContext;
    private Mock<DbSet<Student>>? _mockStudentSet;
    private StudentOperations? _studentOperations;
    private List<Student> _students = new();

    [TestInitialize]
    public void Setup()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DrivingLessonBookingSystemContext>();
        optionsBuilder.UseInMemoryDatabase("DrivingLessonDB");

        _mockContext = new Mock<DrivingLessonBookingSystemContext>(optionsBuilder.Options);
        _mockStudentSet = new Mock<DbSet<Student>>();

        //simulate a real database table using a List<Student>
        _mockStudentSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(_students.AsQueryable().Provider);
        _mockStudentSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(_students.AsQueryable().Expression);
        _mockStudentSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(_students.AsQueryable().ElementType);
        _mockStudentSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => _students.GetEnumerator());

        //mock Add and Remove behavior
        _mockStudentSet.Setup(m => m.Add(It.IsAny<Student>())).Callback<Student>(s => _students.Add(s));
        _mockStudentSet.Setup(m => m.Remove(It.IsAny<Student>())).Callback<Student>(s => _students.Remove(s));

        //return the mocked DbSet from the context
        _mockContext.Setup(c => c.Students).Returns(_mockStudentSet.Object);
        _mockContext.Setup(c => c.SaveChanges()).Returns(1); // Simulate successful DB commit

        //pass the mock context to StudentOperations (important)
        _studentOperations = new StudentOperations(_mockContext.Object);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetIn(new StreamReader(Stream.Null)); //reset console input to prevent memory issues
    }

    [TestMethod]
    public void AddStudent_ShouldAddStudentToDatabase()
    {
        //arrange: Simulate user input for a new student
        var inputSequence = new List<string>
        {
            "zouzou", "mounou", "zoumounou@gmail.com", "ZouzouMounou123!",
            "2003/04/18", "+23058226843", "2 lalaland Main St"
        };
        var input = new StringReader(string.Join(Environment.NewLine, inputSequence));
        Console.SetIn(input);
        
        //act
        _studentOperations!.AddStudent();

        //assert: Verify Add was called and SaveChanges was triggered
        _mockStudentSet!.Verify(s => s.Add(It.IsAny<Student>()), Times.Once);
        _mockContext!.Verify(c => c.SaveChanges(), Times.Once);
        Assert.AreEqual(1, _students.Count);
    }

}