namespace MainProject;

public class LoginMenu
{
    // choose whether you log in as a student, instructor or admin
    // based on that, student and instructor can view the booking where their email appear
    // admin can register new students, instructors and add new cars and lessons.
    public void DisplayLoginMenu()
    {
        Console.WriteLine("Welcome to our driving school booking system. In order to interact with our system, you must login as one of the following:\n1.Student,\n2.Instructor,\n3.Admin");
        string? option;
        while (true)
        {
            Console.Write("Login as (Student/Instructor/Admin): ");
            option = Console.ReadLine();
            if (Validations.ValidateString(option))
            {
                if (option.Equals("student", StringComparison.InvariantCulture) ||
                    option.Equals("instructor", StringComparison.InvariantCulture) ||
                    option.Equals("admin", StringComparison.InvariantCulture))
                {
                    break;
                }

                Console.WriteLine("Invalid option entered, please re-input.");
            }
            else
            {
                Console.WriteLine("Field can't be empty, please re-input.");
            }
        }

        switch (option.ToLower())
        {
            case "student":
                // Student login
                var studentMenu = new StudentMenu();
                studentMenu.Login();
                break;
            case "instructor":
                // Instructor login
                var instructorMenu = new InstructorMenu();
                instructorMenu.Login();
                break;
            case "admin":
                Console.Write("Enter username: ");
                string? username;
                while (true)
                {
                    username = Console.ReadLine();
                    if (Validations.ValidateString(username))
                    {
                        if (username.ToLower().Equals("root", StringComparison.InvariantCulture)) break;
                        Console.WriteLine("Wrong username entered, please re-input.");
                    }
                    else
                    {
                        Console.WriteLine("Password can't be empty.");
                    }
                }
                Console.Write("Enter password: ");
                string? password;
                while (true)
                {
                    password = Console.ReadLine();
                    if (Validations.ValidateString(password))
                    {
                        if (password.ToLower().Equals("root", StringComparison.InvariantCulture)) break;
                        Console.WriteLine("Wrong password entered, please re-input.");
                    }
                    else
                    {
                        Console.WriteLine("Password can't be empty.");
                    }
                }
                
                Console.WriteLine("Choose on which menu you want to proceed:\n1.Student,\n2.Instructor,\n3.Car,\n4.Lesson");
                string? choice;
                while (true)
                {
                    choice = Console.ReadLine().ToLower();
                    if (Validations.ValidateString(choice))
                    {
                        if (choice is "student" or "instructor" or "car" or "lesson" or "lessons")
                        {
                            break;
                        }

                        Console.WriteLine("Invalid choice, choice can either be student, instructor, car or lesson.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice, choice can't be empty.");
                    }
                }

                switch (choice)
                {
                    case "student":
                    case "students":
                        // Student Menu
                        var studentAdminMenu = new StudentMenu();
                        studentAdminMenu.DisplayStudentMenu();
                        break;
                    case "instructor":
                    case "instructors":
                        // Instructor Menu
                        var instructorAdminMenu = new InstructorMenu();
                        instructorAdminMenu.DisplayInstructorMenu();
                        break;
                    case "car":
                    case "cars":
                        // Car Menu
                        var carAdminMenu = new CarMenu();
                        carAdminMenu.DisplayCarMenu();
                        break;
                    case "lesson":
                    case "lessons":
                        // Lesson Menu
                        var lessonAdminMenu = new LessonMenu();
                        lessonAdminMenu.DisplayStudentMenu();
                        break;
                }
                break;
        }
    }
}