using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;
namespace MainProject;

public class LessonOperations
{
    public void AddLesson()
    {
        string studentEmail;
        int studentId;
        while (true)
        {
            Console.Write("Student email: ");
            studentEmail = Console.ReadLine() ?? "";
            if (Validations.ValidateString(studentEmail))
            {
                
                // Validate email
                if (Validations.ValidateEmail(studentEmail))
                {
                    // Check if email is present in student table.
                    if (CheckStudentEmailExistence(studentEmail))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var student = context.Students.Select(s => new
                                {
                                    studentId = s.StudentId,
                                    email = s.Email
                                }).First(s => s.email == studentEmail);
                                studentId = student.studentId;
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Processing Failed: {e.Message}");
                        }
                    }

                    Console.WriteLine("Student email doesn't exist, please re-input.");
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
        string instructorEmail;
        int instructorId;
        while (true)
        {
            Console.Write("Instructor email: ");
            instructorEmail = Console.ReadLine() ?? "";
            if (Validations.ValidateString(instructorEmail))
            {
                
                // Validate email
                if (Validations.ValidateEmail(instructorEmail))
                {
                    // Check if email is present in database.
                    if (CheckInstructorEmailExistence(instructorEmail))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var instructor = context.Instructors.Select(i => new
                                {
                                    instructorId = i.InstructorId,
                                    email = i.Email
                                }).First(i => i.email == instructorEmail);
                                instructorId = instructor.instructorId;
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Processing Failed: {e.Message}");
                        }
                    }

                    Console.WriteLine("Instructor email doesn't exist, please re-input.");
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
        DateOnly lessonDate;
        while (true)
        {
            Console.Write("Lesson date (yyyy/MM/dd): ");
            var date = Console.ReadLine() ?? "";
            if (Validations.ValidateString(date))
            {
                if (Validations.ValidateDate(date))
                {
                    DateOnly.TryParse(date, out lessonDate);
                    break;
                }
                Console.WriteLine("Incorrect date format, please use the format yyyy/MM/dd.");
            }
            else
            {
                Console.WriteLine("Date can't be empty, please re-input.");
            }
        }
        string? registrationNumber;
        int carId;
        while (true)
        {
            Console.Write("Enter the car registration number: ");
            registrationNumber = Console.ReadLine();
            if (Validations.ValidateString(registrationNumber))
            {
                if (CarOperations.CarRegistrationChecker(registrationNumber))
                {
                    if (!CarOperations.IsUnique(registrationNumber))
                    {
                        try
                        {
                            using (var context = new DrivingLessonBookingSystemContext())
                            {
                                var car = context.Cars.Select(c => new
                                {
                                    CarID = c.CarId,
                                    regNumber = c.RegistrationNumber
                                }).First(c => c.regNumber == registrationNumber);
                                carId = car.CarID;
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Processing Failed: {e.Message}");
                        }
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
        //TODO: Add lesson (student id, instructor id, date)
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var lesson = new Lesson()
                {
                    CarId = carId,
                    StudentId = studentId,
                    InstructorId = instructorId,
                    Date = lessonDate
                };
                context.Lessons.Add(lesson);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
    
    private static bool CheckStudentEmailExistence(string email)
    {
        // Connect with Database
        var success = false;
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                success = context.Students.Any(i => i.Email == email);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        return success;
    }
    
    private static bool CheckInstructorEmailExistence(string email)
    {
        // Connect with Database
        var success = false;
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                success = context.Instructors.Any(i => i.Email == email);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        return success;
    }
}