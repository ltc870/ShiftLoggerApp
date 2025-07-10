namespace ShiftLoggerUi.Utils;

public class RunProgramUtil
{
    public static void RunProgram()
    {
        Console.WriteLine("Welcome to the Shift Logger Application!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        UserOptions();
    }

    private static void UserOptions()
    {
        Console.Clear();
        bool applicationRunning = true;

        while (applicationRunning)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("<---------------------------------------------------------->\n");
            Console.WriteLine("Type 0 to Close Program.");
            Console.WriteLine("Type 1 to Manage Employees");
            Console.WriteLine("Type 2 to Manage Shifts");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    applicationRunning = false;
                    Console.WriteLine("Closing Shift Logger Application...");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
                case "1":
                    Console.WriteLine("Manage Employees selected.");
                    // Call method to manage employees
                    break;
                case "2":
                    Console.WriteLine("Manage Shifts selected.");
                    // Call method to manage shifts
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}