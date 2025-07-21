using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        Console.Clear();
        Console.WriteLine("Fetching all employees...");
        
        var employees = await _employeeRepository.GetAllEmployeesAsync();
        
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await Task.FromResult(new List<EmployeeDto>());
        }
        
        Console.WriteLine("Employees:");
        Console.WriteLine("<-------------------------------------------->");
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.EmployeeId} - {employee.Name}");
        }
        
        Console.WriteLine("<-------------------------------------------->");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return employees;
    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("Fetching an employee by ID...");
        await GetAllEmployeesAsync();
        Console.WriteLine("Which employee ID would you like to fetch?");
        int employeeId;
        while (!int.TryParse(Console.ReadLine(), out employeeId))
        {
            Console.WriteLine("Invalid input. Please enter a valid employee ID.");
        }
        var employeeDto = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
        if (employeeDto == null)
        {
            Console.WriteLine($"Employee with ID {employeeId} not found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await Task.FromResult<EmployeeDto>(null);
        }
        Console.WriteLine($"Employee ID: {employeeDto.EmployeeId}, Name: {employeeDto.Name}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return employeeDto;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync()
    {
        Console.Clear();
        Console.WriteLine("Create a new employee...");
        Console.WriteLine("<-------------------------------------------->");
        Console.Write("Enter employee name: ");
        string? employeeName = Console.ReadLine();
        EmployeeDto newEmployee = new EmployeeDto(employeeName);
        
        var employeeDto = await _employeeRepository.CreateEmployeeAsync(newEmployee);
        
        return employeeDto;
    }

    public async Task<EmployeeDto> UpdateEmployeeByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("Update an employee by ID...");
        await GetAllEmployeesAsync();
        Console.WriteLine("Which employee ID would you like to update?");
        int employeeId;
        while(!int.TryParse(Console.ReadLine(), out employeeId))
        {
            Console.WriteLine("Invalid input. Please enter a valid employee ID.");
        }
        Console.Write("Enter new employee name: ");
        string? updatedName = Console.ReadLine();
        EmployeeDto updatedEmployee = new EmployeeDto(updatedName, employeeId);
        var updatedEmployeeDto = await _employeeRepository.UpdateEmployeeByIdAsync(employeeId, updatedEmployee);
        if (updatedEmployeeDto == null)
        {
            Console.WriteLine($"Failed to update employee with ID {employeeId}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await Task.FromResult<EmployeeDto>(null);
        }
        Console.WriteLine($"Employee ID: {updatedEmployeeDto.EmployeeId} - Name: {updatedEmployeeDto.Name}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return updatedEmployeeDto;
    }

    public async Task<bool> DeleteEmployeeByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("Delete an employee by ID...");
        await GetAllEmployeesAsync();
        Console.WriteLine("Please type the ID of the employee would you like to delete");
        int employeeId;
        while (!int.TryParse(Console.ReadLine(), out employeeId))
        {
            Console.WriteLine("Invalid input. Please enter a valid employee ID.");
        }
        var success = await _employeeRepository.DeleteEmployeeByIdAsync(employeeId);
        return true;
    }
}