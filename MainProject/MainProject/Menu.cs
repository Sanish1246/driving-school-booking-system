using MainProject;



// Menu for Student
Console.WriteLine(new string('-',50));
Console.WriteLine("Here is a list of operations that you can perform: \n1. Add Student, \n2. Delete Student, \n3. Search Student, \n4. List all Students");
Console.WriteLine("Choose one of the above options: ");
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
        if (options is < 1 or > 4)
        {
            Console.WriteLine("Invalid option, you should choose between options 1 and 4.");
        }
        else
        {
            break;
        }
    }
}

// Load Tables
var tables = new OfflineDatabase();
tables.LoadTables();
switch (options)
{
    case 1:
        var studentOperation = new StudentOperations();
        studentOperation.AddStudent();
        break;
    default:
        Console.WriteLine("Wrong options");
        break;
}



