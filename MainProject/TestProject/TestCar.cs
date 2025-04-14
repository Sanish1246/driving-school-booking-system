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
    public class TestCar
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

            _context.Cars.RemoveRange(_context.Cars);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddCar()
        {
            var carOps = new CarOperations();
            var input = string.Join(Environment.NewLine, "Toyota", "Automatic", "AB12 XYZ");
            using var reader = new StringReader(input);
            Console.SetIn(reader);

            using var writer = new StringWriter();
            Console.SetOut(writer);

            carOps.AddCar();

            var car = _context.Cars.FirstOrDefault(c => c.RegistrationNumber == "AB12XYZ");
            Assert.IsNotNull(car);
            Assert.AreEqual("Toyota", car.Make);
            Assert.AreEqual("Automatic", car.Transmission);
        }

        [TestMethod]
        public void DeleteCar()
        {
            _context.Cars.Add(new Car
            {
                Make = "Honda",
                Transmission = "Manual",
                RegistrationNumber = "CD34 EFG"
            });
            _context.SaveChanges();

            var carOps = new CarOperations();
            using var reader = new StringReader("CD34 EFG");
            Console.SetIn(reader);

            using var writer = new StringWriter();
            Console.SetOut(writer);

            carOps.DeleteCar();
            _context.SaveChanges();

            var car = _context.Cars.FirstOrDefault(c => c.RegistrationNumber == "CD34 EFG");
            Assert.IsNull(car);
        }

        [TestMethod]
        public void SearchCar()
        {
            _context.Cars.Add(new Car
            {
                Make = "Ford",
                Transmission = "Automatic",
                RegistrationNumber = "EF56 HIJ"
            });
            _context.SaveChanges();

            var input = new StringReader("EF56 HIJ\n");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            var operation = new CarOperations();
            operation.SearchCar();

            var consoleOutput = output.ToString();
            Assert.IsTrue(consoleOutput.Contains("EF56 HIJ"));
            Assert.IsTrue(consoleOutput.Contains("Ford"));
        }

        [TestMethod]
        public void DisplayCar()
        {
            _context.Cars.Add(new Car
            {
                Make = "Nissan",
                Transmission = "Automatic",
                RegistrationNumber = "GH78 KLM"
            });
            _context.Cars.Add(new Car
            {
                Make = "BMW",
                Transmission = "Manuel",
                RegistrationNumber = "IJ90 NOP"
            });
            _context.SaveChanges();

            using var writer = new StringWriter();
            Console.SetOut(writer);

            CarOperations.DisplayCar();

            var output = writer.ToString();
            Assert.IsTrue(output.Contains("Make: Nissan"));
            Assert.IsTrue(output.Contains("Make: BMW"));
        }


   
    }
}
