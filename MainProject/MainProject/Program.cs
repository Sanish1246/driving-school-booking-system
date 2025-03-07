
bool successRegister = false;
int choice = 0;

Console.WriteLine("Welcome to the driving lesson booking system!");
Console.WriteLine("---------------------------------------------");
Console.WriteLine("1.Login");
Console.WriteLine("2. Registration");
Console.WriteLine("3. Exit");
Console.WriteLine("Hello, World!");

while (choice != 1 || choice != 2 || choice !=3)
{
    Console.Write("Choose an option: ");
    choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.Clear();
        break;
    }
    else if (choice == 2)
    {
        Console.Clear();
        do
        {
            successRegister = RegisterUser();
        } while (!successRegister);
        
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

static bool RegisterUser()
{
    bool valid = false;
    bool validPassword=false;
    string username;
    string password;
    Console.Write("Enter a username: ");
        username = Console.ReadLine();
        do
        {
            Console.Write("Enter a password: ");
            password = Console.ReadLine();
            if (password.Length<8 || password.ToUpper()==password || password.ToLower() == password)
            {
                Console.WriteLine("Invalid password! It must have at least 8 charcters, at least 1 upper case letter and at least a lower case letter");
            } else
            {
                validPassword = true;
            }

        } while (!validPassword);

        if (validPassword == true)
        {
            valid=true;
        }

    Console.WriteLine($"Username: {username}");
    Console.WriteLine($"Password: {password}");
    return valid;
}


