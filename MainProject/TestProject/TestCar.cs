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


    }
}
