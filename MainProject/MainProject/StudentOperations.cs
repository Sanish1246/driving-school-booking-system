using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject;
public class StudentOperations
{
    // CRUD Operations for students
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
            if (Validations.ValidateString(firstName)) break;
            Console.WriteLine("First name can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Last Name: ");
            lastName = Console.ReadLine() ?? "";
            if (Validations.ValidateString(lastName)) break;
            Console.WriteLine("Last name can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Email: ");
            email = Console.ReadLine() ?? "";
            if (Validations.ValidateString(email))
            {
                
                // Validate the email
                if (Validations.ValidateEmail(email))
                {
                    // Check if email is already present in database; emails should be unique
                    if (!Validations.CheckEmailExistence(email))
                    {
                        break;
                    }

                    Console.WriteLine("Email already exists, please choose another one.");
                }
                else
                {
                    Console.WriteLine("Wrong email format; format should be in the form John.Doe@example.com, please re-input.");
                }
            }
            else
            {
                Console.WriteLine("Email can't be empty, please re-input.");
            }
        }

        while (true)
        {
            Console.Write("Password: ");
            password = Console.ReadLine() ?? "";
            if (Validations.ValidateString(password))
            {
                if (Validations.ValidatePassword(password))
                {
                    // TODO: Hash password then store in database.
                    // TODO: Double entry-check for password.
                    break;
                }
            }
            else
            {
                Console.WriteLine("Password can't be empty, please re-input.");
            }
        }

        while (true)
        {
            Console.Write("Date of birth (yyyy/MM/dd): ");
            var date = Console.ReadLine() ?? "";
            if (Validations.ValidateString(date))
            {
                if (Validations.ValidateDate(date))
                {
                    DateOnly.TryParse(date, out dateOfBirth);
                    break;
                }
                Console.WriteLine("Incorrect date format, please use the format yyyy/MM/dd.");
            }
            else
            {
                Console.WriteLine("Date can't be empty, please re-input.");
            }
            
        }

        while (true)
        {
            Console.Write("Phone Number: ");
            phoneNumber = Console.ReadLine() ?? "";
            if (Validations.ValidateString(phoneNumber))
            {
                if (Validations.ValidatePhoneNumber(phoneNumber)) break;
                Console.WriteLine("Incorrect phone number format, phone number should be in the format (+230)58226843 where the number in parentheses is optional.");
            }
            else
            {
                Console.WriteLine("Phone number can't be empty, please re-input.");
            }
        }

        while (true)
        {
            Console.Write("Address: ");
            address = Console.ReadLine() ?? "";
            if (Validations.ValidateString(address)) break;
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
                Console.WriteLine("Student added successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed {e.Message}");
        }
    }

    public void DeleteStudent()
    {
        // Delete by email
        string? email;
        while (true)
        {
            Console.Write("Please enter the email of the student you want to delete: ");
            email = Console.ReadLine();
            if (Validations.ValidateString(email))
            {
                if (Validations.ValidateEmail(email))
                {
                    //TODO: Check if email is present in database
                    if (Validations.CheckEmailExistence(email))
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong email format; format should be in the form John.Doe@example.com, please re-input.");
                }
            }
            else
            {
                Console.WriteLine("Email can't be empty, please re-input.");
            }
        }
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                context.Students.Where(s => s.Email == email).ExecuteDelete();
                Console.WriteLine("Student deleted successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void DisplayStudent()
    {
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var students = context.Students.AsNoTracking().ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
}

