int choice=0;
Console.WriteLine("Welcome to the driving lesson booking system!");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("1.Book a Lesson");
Console.WriteLine("2. Exit");

while (choice != 1 || choice != 2)
{
    Console.Write("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.Clear();
        Console.WriteLine("You chose to book a lesson!");
        break;
    } else if (choice == 2)
    {
        Console.Clear();
        Console.WriteLine("Press enter to exit");
        break;
    } else
    {
        Console.WriteLine("Invalid choice! Re-input");
    }
}

Console.ReadKey();
