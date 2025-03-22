using MainProject;
using MainProject.Context;


//Class for the menu
public class MenuHandler
{
    private readonly OfflineDatabase _tables;
    private readonly StudentOperations _studentOperation;

    public MenuHandler(DrivingLessonBookingSystemContext context)
    {
        _tables = new OfflineDatabase();
        _studentOperation = new StudentOperations(context);
    }

    //Menu actions
    public string HandleMenuOption(int option)
    {
        _tables.LoadTables();

        switch (option)
        {
            case 1:
                _studentOperation.AddStudent();
                return "Student added.";
            case 2:
                _studentOperation.DeleteStudent();
                return "Student deleted.";
            case 4:
                _studentOperation.DisplayStudent();
                return "Displaying students.";
            case -1:
                return "Exiting application.";
            default:
                return "Invalid option.";
        }
    }

    public bool ValidateMenuOption(int option)
    {
        return option is >= 1 and <= 4 || option == -1;
    }

    public bool ValidateResponse(string response)
    {
        return !string.IsNullOrWhiteSpace(response) &&
               (response.Trim().ToLower() == "yes" || response.Trim().ToLower() == "no");
    }
}

//Admin menu
public class Menu
{
    public static void Main()
    {
        Console.WriteLine(new string('-', 50));
        
        var dbContext = new DrivingLessonBookingSystemContext();
        
        var menuHandler = new MenuHandler(dbContext);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Here is a list of operations that you can perform: \n1. Add Student, \n2. Delete Student, \n3. Search Student, \n4. List all Students\n5. Enter -1 to exit the application");
            Console.Write("Choose one of the above options: ");
            int option;

            while (true)
            {
                var validOption = int.TryParse(Console.ReadLine(), out option);
                if (!validOption)
                {
                    Console.WriteLine("Your choice should contain only numbers, please re-input.");
                }
                else if (!menuHandler.ValidateMenuOption(option))
                {
                    Console.WriteLine("Invalid option, you should choose between options 1 and 4 or -1 to exit.");
                }
                else
                {
                    break;
                }
            }

            if (option == -1)
            {
                Console.WriteLine("Exiting console application...");
                break;
            }

            string result = menuHandler.HandleMenuOption(option);
            Console.WriteLine(result);

            Console.WriteLine("Do you wish to continue? (Yes/No)");

            string? response;
            while (true)
            {
                response = Console.ReadLine();
                if (menuHandler.ValidateResponse(response))
                {
                    break;
                }
                Console.WriteLine("Response should either be 'yes' or 'no', please re-input.");
            }

            if (response.Trim().ToLower() == "no")
            {
                break;
            }
        }
    }
}