using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MainProject;

//Class for the operations with the car table
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
                    if (IsUnique(registrationNumber))
                    {
                        break;
                    }
                    Console.WriteLine("Registration number is already taken, please re-input.");
                }
                else
                {
                    Console.WriteLine("Invalid format, please re-input.");
                }
            }
            else
            {
                Console.WriteLine("Car registration number can't be empty");
            }
        }

        //Creating a car object and inserting it in the database
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var car = new Car()
                {
                    Make = make,
                    Transmission = transmission,
                    RegistrationNumber = Validations.RemoveWhiteSpaces(registrationNumber.ToUpper())
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

    public void DeleteCar()
    {
        string? registrationNumber;
        while (true)
        {
            Console.Write("Enter the car registration number: ");
            registrationNumber = Console.ReadLine();
            if (Validations.ValidateString(registrationNumber))
            {
                if (CarRegistrationChecker(registrationNumber))
                {
                    if (!IsUnique(registrationNumber))
                    {
                        break;
                    }

                    Console.WriteLine("Car registration number doesn't exist, please re-input.");
                }
                else
                {
                    Console.WriteLine("Invalid registration number format, ensure the format is as: AB99 CDE");
                }
            }

            Console.WriteLine("Registration number can't be empty");
        }

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                context.Cars.Where(c => c.RegistrationNumber == registrationNumber).ExecuteDelete();
                Console.WriteLine("Car successfully deleted.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void SearchCar()
    {
        var registrationNumber = EnterCarReg();

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var cars = context.Cars.Where(c => c.RegistrationNumber == registrationNumber);
                foreach (var car in cars)
                {
                    Console.WriteLine($"Car found with the following details:\n{car}"); 
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void UpdateCar()
    {
        var registrationNumber = EnterCarReg();
        
        while (true)
        {
            // Choose what information to update (first name, last name, email, password, date of birth, address, phone number)
            Console.WriteLine("The following fields can be updated: \n1. Make, \n2. Transmission, \n3. Registration number");
            string? field;
            var validField = false;
            while (true)
            {
                Console.WriteLine("Enter the field you want to update: ");
                field = Console.ReadLine().Trim().ToLower();
                
                // Remove all space characters
                field = Validations.RemoveWhiteSpaces(field);
                if (Validations.ValidateString(field))
                {
                    if (Validations.ValidateLettersOnly(field))
                    {
                        break;
                    }

                    Console.WriteLine("Field should only contain letters.");
                }
                else
                {
                    Console.WriteLine("Field can't be empty, please re-input.");
                }
            }
            
            switch (field)
            {
                case "make":
                    validField = true;
                    UpdateMake(registrationNumber);
                    break;
                case "transmission":
                    validField = true;
                    UpdateTransmission(registrationNumber);
                    break;
                case "registrationnumber":
                    validField = true;
                    UpdateRegistrationNumber(registrationNumber);
                    break;
                default:
                    Console.WriteLine("Invalid field chosen, please re-input.");
                    break;
            }

            if (!validField) continue;
            
            // Continue updating or exit
            string? response;
            while (true)
            {
                Console.WriteLine("Do you wish to continue updating car details? (Yes/No)");
                response = Console.ReadLine();
                if (Validations.ValidateString(response))
                {
                    if (response.Trim().Equals("yes", StringComparison.InvariantCultureIgnoreCase) || response.Trim().Equals("no", StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
            
                    Console.WriteLine("Response should either be yes or no, please re-input.");
                }
                else
                {
                    Console.WriteLine("Response can't be empty, please re-input.");
                }
            }

            if (response.Trim().Equals("no", StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
        }
    }

    public static string EnterCarReg()
    {
        while (true)
        {
            Console.Write("Enter the car registration number: ");
            var registrationNumber = Console.ReadLine();
            if (Validations.ValidateString(registrationNumber))
            {
                if (CarRegistrationChecker(registrationNumber))
                {
                    return registrationNumber;
                }

                Console.WriteLine("Invalid registration number format, ensure the format is as: AB99 CDE");
            }

            Console.WriteLine("Registration number can't be empty");
        }
    }

    private static void UpdateRegistrationNumber(string registrationNumber)
    {

        string? newRegistrationNumber;
        while (true)
        {
            Console.Write("Enter the car registration number: ");
            newRegistrationNumber = Console.ReadLine();
            if (Validations.ValidateString(newRegistrationNumber))
            {
                if (CarRegistrationChecker(newRegistrationNumber))
                {
                    if (IsUnique(newRegistrationNumber))
                    {
                        break;
                    }

                    Console.WriteLine("Registration number is already taken, please re-input.");
                }
                else
                {
                    Console.WriteLine("Invalid registration number format, ensure the format is as: AB99 CDE");
                }
            }
            else
            {
                Console.WriteLine("Registration number can't be empty");
            }
        }

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                context.Cars.Where(c => c.RegistrationNumber == registrationNumber).ExecuteUpdate(
                    setters => setters.SetProperty(c => c.RegistrationNumber, newRegistrationNumber.ToUpper()));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public static void UpdateTransmission(string registrationNumber)
    {
        string? transmission;
        while (true)
        {
            Console.Write("Enter new transmission of the car: ");
            transmission = Console.ReadLine();
            if (Validations.ValidateString(transmission))
            {
                if (TransmissionChecker(transmission))
                {
                    break;
                }

                Console.WriteLine("Transmission can either be automatic or manuel. Please re-input.");
            }
            else
            {
                Console.WriteLine("Transmission can't be empty please re-input.");
            }
        }

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                context.Cars.Where(c => c.RegistrationNumber == registrationNumber)
                    .ExecuteUpdate(setters => setters.SetProperty(c => c.Transmission, transmission));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private static void UpdateMake(string registrationNumber)
    {
        string? make;
        while (true)
        {
            Console.Write("Enter new make of the car: ");
            make = Console.ReadLine();
            if (Validations.ValidateString(make))
            {
                break;
            }
            Console.WriteLine("Make can't be empty please re-input.");
        }

        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                context.Cars.Where(c => c.RegistrationNumber == registrationNumber)
                    .ExecuteUpdate(setters => setters.SetProperty(c => c.Make, make));
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

    private static bool TransmissionChecker(string transmission)
    {
        return transmission.Equals("Automatic", StringComparison.InvariantCultureIgnoreCase) ||
               transmission.Equals("Manuel", StringComparison.InvariantCultureIgnoreCase);
    }

    public static bool CarRegistrationChecker(string registrationNumber)
    {
        var registrationNumberRegex = new Regex(@"^[a-zA-Z]{2}[\d]{2}[\s]?[a-zA-Z]{3}$");
        var m = registrationNumberRegex.Match(registrationNumber);
        return m.Success;
    }

    public static bool IsUnique(string registrationNumber)
    {
        var success = false;
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                success = context.Cars.Any(c => c.RegistrationNumber == registrationNumber);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        return !success;
    }
}