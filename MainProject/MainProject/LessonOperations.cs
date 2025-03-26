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

        DateOnly lessonDate = EnterDate();
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

    public void DeleteLesson()
    {
        //TODO: Delete lesson by date then choose student you want to erase the record of
        DateOnly lessonDate = EnterDate();
        // list all records for specific date, then delete record you want by lesson id.
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var lessons = context.Lessons.Select(lessons => new
                {
                    LessonId = lessons.LessonId,
                    StudentFirstName = lessons.Student.FirstName,
                    StudentLastName = lessons.Student.LastName,
                    StudentEmail = lessons.Student.Email,
                    InstructorFirstName = lessons.Instructor.FirstName,
                    InstructorLastName = lessons.Instructor.LastName,
                    InstructorEmail = lessons.Instructor.Email,
                    CarTransmission = lessons.Car.Transmission,
                    LessonDate = lessons.Date
                }).Where(l => lessonDate.Equals(l.LessonDate));
            
                if (lessons.Any())
                {
                    foreach (var lesson in lessons)
                    {
                        Console.WriteLine(lesson);
                    }
                }
                else
                {
                    Console.WriteLine("No matching dates found.");
                }
                //TODO: From the displayed rows, delete the one you want by ID.
                int lessonId;
                while (true)
                {
                    Console.Write("Enter lesson id: ");
                    var success = int.TryParse(Console.ReadLine(), out lessonId);
                    if (success)
                    {
                        if (lessonId < 0)
                        {
                            Console.WriteLine("Invalid lesson id entered, lesson id should be greater than 0.");
                        }
                        else
                        {
                            // check if lesson id exist in db
                            var result = context.Lessons.Find(lessonId);
                            if (result != null)
                            {
                                break;
                            }
                            Console.WriteLine("Incorrect lesson id, lesson id doesn't exist, please re-enter.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect lesson id, lesson id should be a valid positive number.");
                    }
                }

                context.Lessons.Where(l => l.LessonId == lessonId).ExecuteDelete();
                Console.WriteLine($"Lesson with id {lessonId} successfully deleted.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void DisplayLessons()
    {
        // Display with instructor and student. [student: first name, last name, email, instructor: first name, last name, email, lesson: date]
        using (var context = new DrivingLessonBookingSystemContext())
        {
            var lessons = context.Lessons.Select(lessons => new
            {
                StudentFirstName = lessons.Student.FirstName,
                StudentLastName = lessons.Student.LastName,
                StudentEmail = lessons.Student.Email,
                InstructorFirstName = lessons.Instructor.FirstName,
                InstructorLastName = lessons.Instructor.LastName,
                InstructorEmail = lessons.Instructor.Email,
                CarTransmission = lessons.Car.Transmission,
                LessonDate = lessons.Date
            });
            foreach (var lesson in lessons)
            {
                Console.WriteLine(lesson.ToString().Replace("{","").Replace("}","").TrimStart());
            }
        }
    }

    private static DateOnly EnterDate()
    {
        DateOnly lessonDate;
        while (true)
        {
            Console.Write("Enter lesson date (yyyy/MM/dd): ");
            var date = Console.ReadLine() ?? "";
            if (Validations.ValidateString(date))
            {
                if (Validations.ValidateDate(date))
                {
                    DateOnly.TryParse(date, out lessonDate);
                    return lessonDate;
                }
                Console.WriteLine("Incorrect date format, please use the format yyyy/MM/dd.");
            }
            else
            {
                Console.WriteLine("Date can't be empty, please re-input.");
            }
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