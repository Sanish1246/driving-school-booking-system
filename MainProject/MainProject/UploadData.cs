using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using MainProject.Context;
using MainProject.CSVHeaders;
using MainProject.Models;

namespace MainProject;

public class UplodData
{
    public static bool LoadData()
    {
        // student csv, instructor csv, car csv, followed by lesson csv.
        // read each line of csv, create student object. Add to student context. At very end, save to database.
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.WriteLine(projectDirectory);
        var studentSuccess = UploadStudentData();
        bool instructorSuccess;
        if (studentSuccess)
        {
            instructorSuccess = UploadInstructorData();
        }
        else
        {
            Console.WriteLine("File upload for student table was unsuccessful, loading data directly from database.");
            return false;
        }
        bool carSuccess;
        if (instructorSuccess)
        {
            carSuccess = UploadCarData();
        }
        else
        {
            Console.WriteLine("File upload for instructor table was unsuccessful, loading data directly from database.");
            return false;
        }
        bool lessonSuccess;
        if (carSuccess)
        {
            lessonSuccess = UploadLessonData();
        }
        else
        {
            Console.WriteLine("File upload for car table was unsuccessful, loading data directly from database.");
            return false;
        }

        if (lessonSuccess) return true;
        Console.WriteLine("File upload for lesson table was unsuccessful, loading data directly from database.");
        return false;
    }

    private static bool UploadStudentData()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.Write("Please enter the first csv file for student: ");
        var fileName = Console.ReadLine();
        var fullPath = Path.Combine(projectDirectory, "Data",fileName);
        var studentFileUploadSuccess = false;
        
        if (File.Exists(fullPath))
        {
            // read csv
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<StudentMap>();
                try
                {
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var isStudentUpdated = false;
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<Student>();
                            var email = record.Email;
                            
                            // Check if email is already present in database; emails should be unique
                            if (!StudentOperations.CheckEmailExistence(email))
                            {
                                // Valid email (email doesn't exists)
                                context.Students.Add(record);
                                isStudentUpdated = true;
                            }
                        }

                        if (isStudentUpdated)
                        {
                            context.SaveChanges();
                            Console.WriteLine($"Records from {fileName} have been successfully been uploaded. ");
                        }

                        studentFileUploadSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return studentFileUploadSuccess;
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist...aborting operation to use default values from database");
        }
        
        return studentFileUploadSuccess;
    }

    private static bool UploadInstructorData()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.Write("Please enter the second csv file for instructor: ");
        var fileName = Console.ReadLine();
        var fullPath = Path.Combine(projectDirectory, "Data",fileName);
        var instructorFileUploadSuccess = false;
        
        if (File.Exists(fullPath))
        {
            // read csv
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<InstructorMap>();
                try
                {
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var isInstructorUpdated = false;
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<Instructor>();
                            var email = record.Email;
                            
                            // Check if email is already present in database; emails should be unique
                            if (!InstructorOperations.CheckEmailExistence(email))
                            {
                                // Valid email (email doesn't exists)
                                context.Instructors.Add(record);
                                isInstructorUpdated = true;
                            }
                        }

                        if (isInstructorUpdated)
                        {
                            context.SaveChanges();
                            Console.WriteLine($"Records from {fileName} have been successfully been uploaded. ");
                        }

                        instructorFileUploadSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return instructorFileUploadSuccess;
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist...aborting operation to use default values from database");
        }
        
        return instructorFileUploadSuccess;
    }

    private static bool UploadCarData()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.Write("Please enter the third csv file for car: ");
        var fileName = Console.ReadLine();
        var fullPath = Path.Combine(projectDirectory, "Data",fileName);
        var carFileUploadSuccess = false;
        
        if (File.Exists(fullPath))
        {
            // read csv
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<CarMap>();
                try
                {
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        var isCarUpdated = false;
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var record = csv.GetRecord<Car>();
                            var carReg = record.RegistrationNumber;
                            
                            // Check if car reg is already present in database; car reg should be unique
                            if (CarOperations.IsUnique(carReg))
                            {
                                // Valid car (car reg is unique)
                                context.Cars.Add(record);
                                isCarUpdated = true;
                            }
                        }

                        if (isCarUpdated)
                        {
                            context.SaveChanges();
                            Console.WriteLine($"Records from {fileName} have been successfully been uploaded. ");
                        }

                        carFileUploadSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return carFileUploadSuccess;
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist...aborting operation to use default values from database");
        }
        
        return carFileUploadSuccess;
    }

    private static bool UploadLessonData()
    {
        var workingDirectory = Environment.CurrentDirectory;
        var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Console.Write("Please enter the fourth csv file for lessons: ");
        var fileName = Console.ReadLine();
        var fullPath = Path.Combine(projectDirectory, "Data",fileName);
        var lessonFileUploadSuccess = false;
        
        if (File.Exists(fullPath))
        {
            // read csv
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using (var reader = new StreamReader(fullPath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<LessonMap>();
                try
                {
                    using (var context = new DrivingLessonBookingSystemContext())
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            // Allow duplicates
                            var record = csv.GetRecord<Lesson>();
                            context.Lessons.Add(record);
                        }
                        context.SaveChanges();
                        Console.WriteLine($"Records from {fileName} have been successfully been uploaded. ");

                        lessonFileUploadSuccess = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return lessonFileUploadSuccess;
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist...aborting operation to use default values from database");
        }
        return lessonFileUploadSuccess;
    }
}