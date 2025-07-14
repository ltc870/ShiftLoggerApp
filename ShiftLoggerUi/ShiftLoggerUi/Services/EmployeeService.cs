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
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> CreateEmployeeAsync()
    {
        Console.Clear();
        Console.WriteLine("Create a new employee!");
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