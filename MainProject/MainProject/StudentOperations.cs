using System.Text.RegularExpressions;
using System.Globalization;
using MainProject.Context;
using MainProject.Models;

namespace MainProject;
public class StudentOperations
{
    // CRUD Operations for students

    // Student
    public void AddStudent()
    {
        string? firstName;
        string? lastName;
        string? email;
        string? password; 
        DateOnly dateOfBirth;
        string? address;
        string? phoneNumber;

        Console.WriteLine("A student consists of the following properties: ");

        while (true)
        {
            Console.Write("First Name: ");
            firstName = Console.ReadLine() ?? "";
            if (ValidateString(firstName)) break;
            Console.WriteLine("First name can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Last Name: ");
            lastName = Console.ReadLine() ?? "";
            if (ValidateString(lastName)) break;
            Console.WriteLine("Last name can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine() ?? "";
            if (ValidateString(email))
            {
                // TODO: Check if email is already present in database; email should be unique.
                // Validate the email
                if (ValidateEmail(email)) break;
            }
            Console.WriteLine("Email can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Password: ");
            password = Console.ReadLine() ?? "";
            if (ValidateString(password))
            {
                if (ValidatePassword(password))
                {
                    // TODO: Hash password then store in database.
                    break;
                }
            }
            Console.WriteLine("Password can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Date of birth (dd/MM/yyyy): ");
            var date = Console.ReadLine() ?? "";
            if (ValidateString(date))
            {
                if (ValidateDate(date))
                {
                    DateOnly.TryParse(date, out dateOfBirth);
                    break;
                }
                Console.WriteLine("Incorrect date format, please use the format yyyy/MM/dd.");
            }
            Console.WriteLine("Date can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Phone Number: ");
            phoneNumber = Console.ReadLine() ?? "";
            if (ValidateString(phoneNumber))
            {
                if (ValidatePhoneNumber(phoneNumber)) break;
                Console.WriteLine("Incorrect phone number format, phone number should be in the format (+230)58226843 where the number in parentheses is optional.");
            }
            Console.WriteLine("Phone number can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Address: ");
            address = Console.ReadLine() ?? "";
            if (ValidateString(address)) break;
            Console.WriteLine("Address can't be empty, please re-input.");
        }


        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Add new student
                var student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    Email = email,
                    DateOfBirth = dateOfBirth,
                    Password = password,
                    PhoneNumber = phoneNumber
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed {e.Message}");
        }
    }

    bool ValidateString(string text) => !string.IsNullOrEmpty(text);

    bool ValidateEmail(string email)
    {
        var emailRegex = new Regex(@"\w+@[a-zA-Z\.]+\.\w+");
        return emailRegex.IsMatch(email);
    }

    bool ValidatePassword(string password)
    {
        var passwordRegex = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&*\(\)\-\!+\?])[A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,}");
        const string uppercasePattern = "(.*[A-Z])";
        const string lowercasePattern = "(.*[a-z])";
        const string digitPattern = @"(.*\d)";
        const string symbolPattern = @"(.*[@#$%^&*\(\)\-\!+\?])";
        const string lengthPattern = @"([A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,})";

        var containUpperCase = Regex.IsMatch(password, uppercasePattern);
        var containLowerCase = Regex.IsMatch(password, lowercasePattern);
        var containDigit = Regex.IsMatch(password, digitPattern);
        var containSymbol = Regex.IsMatch(password, symbolPattern);
        var validLength = Regex.IsMatch(password, lengthPattern);

        if (!containUpperCase) Console.WriteLine("Password should contain at least one uppercase letter.");
        if (!containLowerCase) Console.WriteLine("Password should contain at least one lowercase letter.");
        if (!containDigit) Console.WriteLine("Password should contain at least one digit.");
        if (!containSymbol) Console.WriteLine("Password should contain at least one special character.");
        if (!validLength) Console.WriteLine("Password is too short, it should be at least 12 characters long.");

        return passwordRegex.IsMatch(password);
    }

    bool ValidateDate(string date)
    {
        var format = "yyyy/MM/dd";
        return DateOnly.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }

    bool ValidatePhoneNumber(string phoneNumber)
    {
        var phoneNumberRegex = new Regex(@"(\(\+\d+\))?((\s+)?\d{8})");
        return phoneNumberRegex.IsMatch(phoneNumber.Trim());
    }
}

