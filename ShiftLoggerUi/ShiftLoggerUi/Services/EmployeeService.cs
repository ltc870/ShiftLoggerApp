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
    
    public Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        Console.Clear();
        Console.WriteLine("Fetching all employees...");
        Console.WriteLine("<-------------------------------------------->");
        
        var employees = _employeeRepository.GetAllEmployeesAsync();
        
        if (employees.Result.Count == 0)
        {
            Console.WriteLine("No employees found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return Task.FromResult(new List<EmployeeDto>());
        }
        
        Console.WriteLine("Employees:");
        foreach (var employee in employees.Result)
        {
            Console.WriteLine($"{employee.EmployeeId} - {employee.Name}");
        }
        
        Console.WriteLine("<-------------------------------------------->");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return employees;
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync()
    {
        throw new NotImplementedException();
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

    public Task<EmployeeDto> UpdateEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }
}