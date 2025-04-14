using MainProject.Context;
using MainProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MainProject;
public class StudentOperations
{
    // CRUD Operations for students
    public void AddUser()
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
            if (Validations.ValidateString(firstName))
            {
                break;
            }
            Console.WriteLine("First name can't be empty, please re-input.");
        }

        while (true)
        {
            Console.Write("Last Name: ");
            lastName = Console.ReadLine() ?? "";
            if (Validations.ValidateString(lastName))
            {
                break;
            }
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
                    if (!CheckEmailExistence(email))
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
            var table = new OfflineDatabase();
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
                // Add student to hash table
                table.StudentTable.Insert(email,student);
                
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

    public void DeleteUser()
    {
        // Delete by email
        var email = EnterEmail();
        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Delete user in hash table
                table.StudentTable.Delete(email);
                
                context.Students.Where(s => s.Email == email).ExecuteDelete();
                Console.WriteLine("Student deleted successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void UpdateUser()
    {
        
        while (true)
        {
            var email = EnterEmail();
            // Choose what information to update (first name, last name, email, password, date of birth, address, phone number)
            Console.WriteLine("The following fields can be updated: \n1. First Name, \n2. Last Name, \n3. Email, \n4. Password, \n5. Date of birth, \n6. Address, \n7. Phone number");
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
                case "firstname":
                    validField = true;
                    UpdateFirstName(email);
                    break;
                case "lastname":
                    validField = true;
                    UpdateLastName(email);
                    break;
                case "email":
                    validField = true;
                    UpdateEmail(email);
                    break;
                case "password":
                    validField = true;
                    UpdatePassword(email);
                    break;
                case "dateofbirth":
                    validField = true;
                    UpdateDateOfBirth(email);
                    break;
                case "address":
                    validField = true;
                    UpdateAddress(email);
                    break;
                case "phonenumber":
                    validField = true;
                    UpdatePhoneNumber(email);
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
                Console.WriteLine("Do you wish to continue updating student details? (Yes/No)");
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

    public static string EnterEmail()
    {
        while (true)
        {
            Console.Write("Enter the email address of the student: ");
            var email = Console.ReadLine();
            if (Validations.ValidateString(email))
            {
                if (Validations.ValidateEmail(email))
                {
                    if (CheckEmailExistence(email))
                    {
                        return email;
                    }
                    
                    Console.WriteLine("Email doesn't exist, please re-input.");
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
    }

    public void UpdateFirstName(string email)
    {
        string? firstName;
        while (true)
        {
            Console.Write("Enter new first name: ");
            firstName = Console.ReadLine();
            if (Validations.ValidateString(firstName))
            {
                break;
            }
            Console.WriteLine("First name can't be empty, please re-input.");
        }

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].FirstName = firstName;
                table.StudentTable.Insert(email, result[0]);
                
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.FirstName, firstName));
                Console.WriteLine("First name updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
    public void UpdateLastName(string email)
    {
        string? lastName;
        while (true)
        {
            Console.Write("Enter new last name: ");
            lastName = Console.ReadLine();
            if (Validations.ValidateString(lastName))
            {
                break;
            }
            Console.WriteLine("Last name can't be empty, please re-input.");
        }

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].LastName = lastName;
                table.StudentTable.Insert(email, result[0]);
                
                // Update into DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.LastName, lastName));
                Console.WriteLine("Last name updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void UpdateEmail(string email)
    {
        string? newEmail;
        while (true)
        {
            Console.Write("Enter new email: ");
            newEmail = Console.ReadLine();
            if (Validations.ValidateString(newEmail))
            {
                if (Validations.ValidateEmail(newEmail))
                {
                    if (!CheckEmailExistence(newEmail))
                    {
                        break;
                    }
                    Console.WriteLine("Email already exist, choose another one.");
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
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].Email = email;
                table.StudentTable.Insert(email, result[0]);
                
                // Update into DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Email, newEmail));
                Console.WriteLine("Email updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private void UpdatePassword(string email)
    {
        string? password;
        while (true)
        {
            Console.Write("Enter new password: ");
            password = Console.ReadLine();
            if (Validations.ValidateString(password))
            {
                if (Validations.ValidatePassword(password))
                {

                    break;
                }
            }
            else
            {
                Console.WriteLine("Password can't be empty, please re-input.");
            }
        }

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].Password = password;
                table.StudentTable.Insert(email, result[0]);
                
                // Update into DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Password, password));
                Console.WriteLine("Password updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private void UpdateDateOfBirth(string email)
    {
        string? date;
        DateOnly dateOfBirth;
        while (true)
        {
            Console.Write("Enter new date of birth (yyyy/MM/dd): ");
            date = Console.ReadLine();
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

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].DateOfBirth = dateOfBirth;
                table.StudentTable.Insert(email, result[0]);
                
                // Update in DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.DateOfBirth, dateOfBirth));
                Console.WriteLine("Date of birth updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private void UpdateAddress(string email)
    {
        string? address;
        while (true)
        {
            Console.Write("Enter new address: ");
            address = Console.ReadLine();
            if (Validations.ValidateString(address))
            {
                break;
            }
            Console.WriteLine("Address can't be empty, please re-input.");
        }

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].Address = address;
                table.StudentTable.Insert(email, result[0]);
                
                // Update in DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.Address, address));
                Console.WriteLine("Address updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    private void UpdatePhoneNumber(string email)
    {
        string? phoneNumber;
        while (true)
        {
            Console.Write("Enter new phone number: ");
            phoneNumber = Console.ReadLine();
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

        try
        {
            var table = new OfflineDatabase();
            table.LoadTables();
            using (var context = new DrivingLessonBookingSystemContext())
            {
                // Update into HashTable
                var result = table.StudentTable.Where(s => s.Email.Equals(email, StringComparison.InvariantCulture)).ToArray();
                table.StudentTable.Delete(email);
                result[0].PhoneNumber = phoneNumber;
                table.StudentTable.Insert(email, result[0]);
                
                // Update into DB
                context.Students.Where(s => s.Email == email).ExecuteUpdate(setters => setters.SetProperty(s => s.PhoneNumber, phoneNumber));
                Console.WriteLine("Phone number updated successfully.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }

    public void SearchUser()
    {
        string email;
        while (true)
        {
            Console.Write("Enter the email address of the student: ");
            email = Console.ReadLine();
            if (Validations.ValidateString(email))
            {
                if (Validations.ValidateEmail(email))
                {
                    if (CheckEmailExistence(email))
                    {
                        break;
                    }
                    
                    Console.WriteLine("Email doesn't exist, please re-input.");
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
                var students = context.Students.Where(s => s.Email == email);
                foreach (var student in students)
                {
                    Console.WriteLine($"Student found with details:\n{student}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
    public void DisplayUser()
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
    
    public static bool CheckEmailExistence(string email)
    {
        // Connect with Database
        var success = false;
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                success = context.Students.Any(s => s.Email == email);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        return success;
    }

    public static bool EnterPassword(string email)
    {
        string? password;
        var success = false;
        while (true)
        {
            Console.Write("Enter password: ");
            password = Console.ReadLine();
            if (Validations.ValidateString(password))
            {
                break;
            }

            Console.WriteLine("Password can't be empty, please re-input");

        }
        // check if password entered matches the one for particular user in the database
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var student = context.Students.Where(s => s.Email == email).ToList();
                if (student[0].Password == password)
                {
                    // password is valid
                    success = true;
                }
                else
                {
                    Console.WriteLine("Incorrect Password entered. Please re-input.");
                }
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }

        return success;
    }

    public static void ViewStudentLessons(string email)
    {
        try
        {
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
                }).Where(l => email.Equals(l.StudentEmail));
                foreach (var lesson in lessons)
                {
                    Console.WriteLine(lesson.ToString().Replace("{","").Replace("}","").Trim());
                }
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
    
    public static void AddStudentLesson(string studentEmail)
    {
        var studentId = 0;
        var studentOperation = false;
        var instructorOperation = false;
        var carOperation = false;
        try
        {
            using (var context = new DrivingLessonBookingSystemContext())
            {
                var result = context.Students.First(s => studentEmail == s.Email);
                studentId = result.StudentId;
                studentOperation = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
        // Give a date, an instructor, a car transmission (automatic/manual)
        Console.WriteLine("In order to register for a new lesson, the following information need to be entered:\n1.Instructor email,\n2.Car Transmission(Automatic/Manual),\n3.Lesson date");
        Console.WriteLine("Let's start with the instructors. Find the list of the registered instructors:");
        
        // List all instructors email
        InstructorOperations.ListAllInstructorEmail();
        Console.WriteLine("Choose one from the available instructors.");
        
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
                    if (LessonOperations.CheckInstructorEmailExistence(instructorEmail))
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
                                instructorOperation = true;
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


        Console.WriteLine("Here is a list of all the cars available:");
        // List all cars
        CarOperations.DisplayCar();
        
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
                                carOperation = true;
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
        
        DateOnly lessonDate = LessonOperations.EnterDate();
        
        try
        {
            if (studentOperation && instructorOperation && carOperation)
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
            else
            {
                Console.WriteLine($"Processing failed.");
            }
           
        }
        catch (Exception e)
        {
            Console.WriteLine($"Processing failed: {e.Message}");
        }
    }
}

