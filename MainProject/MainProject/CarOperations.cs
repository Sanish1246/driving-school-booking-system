using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MainProject;

public class CarOperations
{
    public void AddCar()
    {
        // Car consist of make, model and registration number.
        Console.WriteLine("A car consists of the following properties:");
        string? make;
        string? transmission;
        string? registrationNumber;
        while (true)
        {
            Console.Write("Enter make of car: ");
            make = Console.ReadLine();
            if (Validations.ValidateString(make))
            {
                break;
            }

            Console.WriteLine("Make can't be empty");
        }
        while (true)
        {
            Console.Write("Enter transmission of car: ");
            transmission = Console.ReadLine();
            if (Validations.ValidateString(transmission))
            {
                // Transmission can either be automatic or manuel
                if (TransmissionChecker(transmission))
                {
                    break;
                }
                Console.WriteLine("Transmission can either be automatic or manuel, please re-input.");
            }
            else
            {
                Console.WriteLine("Transmission can't be empty, please re-input");
            }
        }
        while (true)
        {
            Console.Write("Enter car registration number in the format (AB99 CDE): ");
            registrationNumber = Console.ReadLine();
            if (Validations.ValidateString(registrationNumber))
            {
                if (CarRegistrationChecker(registrationNumber))
                {
                    break;
                }

                Console.WriteLine("Invalid format, please re-input.");
            }
            else
            {
                Console.WriteLine("Car registration number can't be empty");
            }
        }

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var car = new Car()
                {
                    Make = make,
                    Transmission = transmission,
                    RegistrationNumber = registrationNumber.ToUpper()
                };
                context.Cars.Add(car);
                context.SaveChanges();
                Console.WriteLine("Car added successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void DisplayCar()
    {
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var cars = context.Cars.AsNoTracking().ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    static bool TransmissionChecker(string transmission)
    {
        if (transmission.Equals("Automatic", StringComparison.InvariantCultureIgnoreCase) ||
            transmission.Equals("Manuel", StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }

        return false;
    }

    static bool CarRegistrationChecker(string registrationNumber)
    {
        var registrationNumberRegex = new Regex(@"^[a-zA-Z]{2}[\d]{2}[\s]?[a-zA-Z]{3}$");
        var m = registrationNumberRegex.Match(registrationNumber);
        return m.Success;
    }
}