namespace MainProject;

public class LessonMenu : LessonOperations
{
    public void DisplayStudentMenu()
    {
        // Menu for lesson
        Console.WriteLine(new string('-',50));
        while (true)
        {
            Console.WriteLine("Here is a list of operations that you can perform: \n1. Add lesson, \n2. Delete lesson, \n3. Update lesson details, \n4. Search lesson by date, \n5. List all lessons\n6. Enter -1 to exit the application");
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
            // Load Tables
            var tables = new OfflineDatabase();
            // tables.LoadTables();
            var lessonOperations = new LessonMenu();
            switch (options)
            {
                case 1:
                    lessonOperations.AddLesson();
                    break;
                case 2:
                    lessonOperations.DeleteLesson();
                    break;
                case 3:
                    lessonOperations.UpdateLessons();
                    break;
                case 4:
                    lessonOperations.SearchDate();
                    break;
                case 5:
                    lessonOperations.DisplayLessons();
                    break;
            }

            Console.WriteLine("Do you want to perform any other operations on the lesson table? (Yes/No)");
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