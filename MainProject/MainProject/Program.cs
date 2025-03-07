Console.WriteLine("Hello, World!");

int choice = 0;
Console.WriteLine("Welcome to the driving lesson booking system!");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("1.Login");
Console.WriteLine("2. Registration");
Console.WriteLine("3. Exit");
Console.WriteLine("Hello, World!");

while (choice != 1 || choice != 2)
{
    Console.Write("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.Clear();
        LoginUser();
        break;
    }
    else if (choice == 2)
    {
        Console.Clear();
        
        break;
    }
    else if (choice == 3)
    {
        Console.Clear();
        Console.WriteLine("Press enter to exit");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice! Re-input");
    }
}

Console.ReadKey();


