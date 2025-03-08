
bool successRegister = false;
int choice = 0;
string username;
string password;

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
        do
        {
            Console.Clear();
            Console.Write("Enter a username: ");
            username = Console.ReadLine();

            Console.Write("Enter a password: ");
            password = Console.ReadLine();

            successRegister = RegisterUser(username, password);
            if (!successRegister)
            {
                Console.ReadLine();
            }
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

static bool ValidatePassword(string password)
{
    if (password.Length < 8 || password.ToUpper() == password || password.ToLower() == password)
    {
        Console.WriteLine("Invalid password! It must have at least 8 charcters, at least 1 upper case letter and at least a lower case letter");
        return false;
    }
    return true;
}

static bool ValidateUserName(string username)
{
    if (username.Length < 8 || username.Length>20)
    {
        Console.WriteLine("Invalid username! It must be between 8 and 20 characters");
        return false;
    }
    return true;
}


static bool RegisterUser(string username, string password)
{
    return ValidatePassword(password) && ValidateUserName(username);
}


