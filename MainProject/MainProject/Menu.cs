using MainProject;



// Menu for Student
Console.WriteLine(new string('-',50));
while (true)
{
    Console.WriteLine("Here is a list of operations that you can perform: \n1. Add Student, \n2. Delete Student, \n3. Search Student, \n4. List all Students\n5. Enter -1 to exit the application");
    Console.Write("Choose one of the above options: ");
    int options;

    while (true)
    {
        var validOptions = int.TryParse(Console.ReadLine(), out options);
        if (!validOptions)
        {
            Console.WriteLine("Your choice should contain only numbers, please re-input.");
        }
        else
        {
            if (options is < 1 or > 4 && options != -1)
            {
                Console.WriteLine("Invalid option, you should choose between options 1 and 4 or -1 to exit.");
            }
            else
            {
                break;
            }
        }
    }
    if (options == -1)
    {
        Console.WriteLine("Exiting console application...");
        break;
    }
    // Load Tables
    var tables = new OfflineDatabase();
    tables.LoadTables();
    var studentOperation = new StudentOperations();

    switch (options)
    {
        case 1:
            studentOperation.AddStudent();
            break;
        case 2:
            studentOperation.DeleteStudent();
            break;
        case 4:
            studentOperation.DisplayStudent();
            break;
        default:
            Console.WriteLine("Wrong options");
            break;
    }

    Console.WriteLine("Do you wish to continue? (Yes/No)");
    string? response;
    while (true)
    {
        response = Console.ReadLine();
        if (Validations.ValidateString(response))
        {
            if (response.Trim().ToLower() == "yes" || response.Trim().ToLower() == "no")
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

    if (response.Trim().ToLower() == "no")
    {
        break;
    }
}



