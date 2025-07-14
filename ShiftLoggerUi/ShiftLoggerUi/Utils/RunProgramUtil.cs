using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services;

namespace ShiftLoggerUi.Utils;

public class RunProgramUtil
{
    public static async Task RunProgram()
    {
        Console.WriteLine("Welcome to the Shift Logger Application!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        await UserOptions();
    }

    private static async Task UserOptions()
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
                    await ManageEmployees();
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

    private static async Task ManageEmployees()
    {
        Console.Clear();
        bool employeeManagementRunning = true;
        EmployeeService employeeService = new EmployeeService(new EmployeeRepository());
        
        
        while (employeeManagementRunning)
        {
            Console.Clear();
            Console.WriteLine("Employee Management Menu:");
            Console.WriteLine("<---------------------------------------------------------->\n");
            Console.WriteLine("Type 0 to Return to Main Menu.");
            Console.WriteLine("Type 1 to View All Employees");
            Console.WriteLine("Type 2 To View An Employee");
            Console.WriteLine("Type 3 To Add An Employee");
            Console.WriteLine("Type 4 To Update An Employee");
            Console.WriteLine("Type 5 To Delete An Employee");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    employeeManagementRunning = false;
                    await UserOptions();
                    break;
                case "1":
                    Console.WriteLine("View All Employees selected.");
                    // Call method to view all employees
                    break;
                case "2":
                    Console.WriteLine("View An Employee selected.");
                    // Call method to view an employee
                    break;
                case "3":
                    Console.WriteLine("Add An Employee selected.");
                    await employeeService.CreateEmployeeAsync();
                    break;
                case "4":
                    Console.WriteLine("Update An Employee selected.");
                    // Call method to update an employee
                    break;
                case "5":
                    Console.WriteLine("Delete An Employee selected.");
                    // Call method to delete an employee
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