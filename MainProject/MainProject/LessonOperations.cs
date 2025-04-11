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
            else
            {
                Console.WriteLine("Registration number can't be empty");
            }
        }
        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
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
                
                // Add to hash table
                Console.WriteLine(lesson.LessonId);
                table.LessonTable.Insert(lesson.LessonId, lesson);
                
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void DeleteLesson()
    {
        
        DateOnly lessonDate = EnterDate();
        
        // list all records for specific date, then delete record by lesson id.
        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
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
                
                // Delete from hash table
                table.LessonTable.Delete(lessonId);
                
                context.Lessons.Where(l => l.LessonId == lessonId).ExecuteDelete();
                Console.WriteLine($"Lesson with id {lessonId} successfully deleted.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void UpdateLessons()
    {
        Console.WriteLine(new string('-',20));
        DisplayLessons();
        Console.WriteLine(new string('-',20));
        var lessonDate = EnterDate();
        if (CheckDate(lessonDate))
        {
            while (true)
            {
                Console.WriteLine("The following fields can be updated:\n1.Student first name,\n2.Student last name,\n3.Student email,\n4.Instructor first name,\n5.Instructor second name,\n6.Instructor email,\n7.Car transmission,\n8.Lesson date");
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
                var studentOperations = new StudentOperations();
                var instructorOperations = new InstructorOperations();
                string? email;
                string? carReg;
                switch (field)
                {
                    case "studentfirstname":
                        validField = true;
                        email = StudentOperations.EnterEmail();
                        studentOperations.UpdateFirstName(email);
                        break;
                    case "studentlastname":
                        validField = true;
                        email = StudentOperations.EnterEmail();
                        studentOperations.UpdateLastName(email);
                        break;
                    case "studentemail":
                        validField = true;
                        email = StudentOperations.EnterEmail();
                        studentOperations.UpdateEmail(email);
                        break;
                    case "instructorfirstname":
                        validField = true;
                        email = InstructorOperations.EnterEmail();
                        instructorOperations.UpdateFirstName(email);
                        break;
                    case "instructorlastname":
                        validField = true;
                        email = InstructorOperations.EnterEmail();
                        instructorOperations.UpdateLastName(email);
                        break;
                    case "instructoremail":
                        validField = true;
                        email = InstructorOperations.EnterEmail();
                        instructorOperations.UpdateEmail(email);
                        break;
                    case "cartransmission":
                        validField = true;
                        carReg = CarOperations.EnterCarReg();
                        CarOperations.UpdateTransmission(carReg);
                        break;
                    case "lessondate":
                        validField = true;
                        UpdateDate(lessonDate);
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
                    Console.WriteLine("Do you wish to continue updating lesson details for this particular date? (Yes/No)");
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
        else
        {
            Console.WriteLine("No matching dates found.");
        }
    }

    public void SearchDate()
    {
        try
        {
            // Search by date
            var lessonDate = EnterDate();
            if (CheckDate(lessonDate))
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
                }
            }
            else
            {
                Console.WriteLine("No matching dates found.");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private bool CheckDate(DateOnly lessonDate)
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
            
            return lessons.Any();
        }
    }
    private void UpdateDate(DateOnly lessonDate)
    {
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

                var newDate = EnterDate();

                context.Lessons.Where(l => l.LessonId == lessonId).ExecuteUpdate(setters => setters.SetProperty(l => l.Date, newDate));
                Console.WriteLine($"Lesson with id {lessonId} has been successfully updated.");
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

    public static DateOnly EnterDate()
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
    
    public static bool CheckInstructorEmailExistence(string email)
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