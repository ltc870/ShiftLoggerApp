using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Utils;

public class RunProgramUtil
{
    private readonly IEmployeeService _employeeService;
    private readonly IShiftService _shiftService;
    
    public RunProgramUtil(IEmployeeService employeeService, IShiftService shiftService)
    {
        _employeeService = employeeService;
        _shiftService = shiftService;
    }
    
    public async Task RunProgram()
    {
        Console.WriteLine("Welcome to the Shift Logger Application!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        await UserOptions();
    }

    private async Task UserOptions()
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
                    await ManageShifts();
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task ManageEmployees()
    {
        Console.Clear();
        bool employeeManagementRunning = true;
        
        
        
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
                    await _employeeService.GetAllEmployeesAsync();
                    break;
                case "2":
                    Console.WriteLine("View An Employee selected.");
                    await _employeeService.GetEmployeeByIdAsync();
                    break;
                case "3":
                    Console.WriteLine("Add An Employee selected.");
                    await _employeeService.CreateEmployeeAsync();
                    break;
                case "4":
                    Console.WriteLine("Update An Employee selected.");
                    await _employeeService.UpdateEmployeeByIdAsync();
                    break;
                case "5":
                    Console.WriteLine("Delete An Employee selected.");
                    await _employeeService.DeleteEmployeeByIdAsync();
                    break;
                default:
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task ManageShifts()
    {
        Console.Clear();
        bool shiftManagementRunning = true;
        ShiftService shiftService = new ShiftService(new EmployeeService(new EmployeeRepository(new HttpClient())), new ShiftRepository(new HttpClient()));

        while (shiftManagementRunning)
        {
            Console.Clear();
            Console.WriteLine("Shift Management Menu:");
            Console.WriteLine("<---------------------------------------------------------->\n");
            Console.WriteLine("Type 0 to Return to Main Menu.");
            Console.WriteLine("Type 1 to View All Shifts");
            Console.WriteLine("Type 2 To View A Shift");
            Console.WriteLine("Type 3 To Add A Shift");
            Console.WriteLine("Type 4 To Update A Shift");
            Console.WriteLine("Type 5 To Delete A Shift");
            Console.WriteLine("Type 6 To View Shifts By Employee");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    Console.Clear();
                    shiftManagementRunning = false;
                    await UserOptions();
                    break;
                case "1":
                    Console.WriteLine("View all shifts selected.");
                    await _shiftService.GetAllShiftsAsync();
                    break;
                case "2":
                    Console.WriteLine("View a shift by ID selected.");
                    await _shiftService.GetShiftByIdAsync();
                    break;
                case "3":
                    Console.WriteLine("Add a shift selected.");
                    await _shiftService.CreateShiftAsync();
                    break;
                case "4":
                    Console.WriteLine("Update a shift selected.");
                    // await shiftService.UpdateShiftByIdAsync();
                    break;
                case "5":
                    Console.WriteLine("Delete a shift selected.");
                    // await shiftService.DeleteShiftByIdAsync();
                    break;
                case "6":
                    Console.WriteLine("View shifts by employee selected.");
                    // await shiftService.GetShiftsByEmployeeAsync();
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