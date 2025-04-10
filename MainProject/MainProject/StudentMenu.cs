namespace MainProject;

public class StudentMenu : StudentOperations
{
    public void DisplayStudentMenu()
    {
        // Menu for Student
        Console.WriteLine(new string('-',50));
        while (true)
        {
            Console.WriteLine("Here is a list of operations that you can perform: \n1. Add Student, \n2. Delete Student, \n3. Update Student details, \n4. Search student, \n5. List all Students\n6. Enter -1 to exit the application");
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
                    if (options is < 1 or > 5 && options != -1)
                    {
                        Console.WriteLine("Invalid option, you should choose between options 1 and 5 or -1 to exit.");
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
            // Load Hash table
            var tables = new OfflineDatabase();
            tables.LoadTables();
            var studentOperations = new StudentMenu();
            switch (options)
            {
                case 1:
                    studentOperations.AddUser();
                    break;
                case 2:
                    studentOperations.DeleteUser();
                    break;
                case 3:
                    studentOperations.UpdateUser();
                    break;
                case 4:
                    studentOperations.SearchUser();
                    break;
                case 5:
                    tables.StudentTable.Display();
                    // studentOperations.DisplayUser();
                    break;
            }

            Console.WriteLine("Do you want to perform any other operations on the student table? (Yes/No)");
            string? response;
            while (true)
            {
                response = Console.ReadLine();
                if (Validations.ValidateString(response))
                {
                    if (response.Trim().Equals("yes", StringComparison.InvariantCultureIgnoreCase) || response.Trim().Equals("no", StringComparison.InvariantCultureIgnoreCase))
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

            if (response.Trim().Equals("no", StringComparison.InvariantCultureIgnoreCase))
            {
                break;
            }
        }
    }
}