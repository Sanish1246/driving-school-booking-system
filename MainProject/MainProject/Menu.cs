using MainProject;
using MainProject.Models;


// Menu for Student
Console.WriteLine(new string('-',50));
Console.WriteLine("Here is a list of operations that you can perform: \n1. Add Student, \n2. Delete Student, \n3. Search Student, \n4. List all Students");
Console.WriteLine("Choose one of the above options: ");

while (true)
{
    var success = int.TryParse(Console.ReadLine(), out var options);
    if (!success)
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

void AddStudent()
{
    Console.WriteLine("A student consist of the following properties: ");
    Console.Write("");
}

