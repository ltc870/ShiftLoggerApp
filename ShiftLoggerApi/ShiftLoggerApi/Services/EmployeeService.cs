using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;
using ShiftLoggerApi.Repositories;
using ShiftLoggerApi.Repositories.Interfaces;
using ShiftLoggerApi.Services.Interfaces;

namespace ShiftLoggerApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        List<Employee> employees = await _employeeRepository.GetAllEmployeesAsync();
        List<EmployeeDto> employeeDtos = employees.Select(employee => new EmployeeDto(employee.EmployeeId, employee.Name)).ToList();
        return employeeDtos;

    }

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        Employee employee = await _employeeRepository.GetEmployeeByIdAsync(id);
        
        if (employee == null)
        {
            throw new KeyNotFoundException($"Employee with ID {id} not found.");
        }
        
        EmployeeDto employeeDto = new EmployeeDto(employee.EmployeeId, employee.Name);
        return employeeDto;
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
    {
        Employee employee = new Employee
        {
            Name = employeeDto.Name,
        };
        
        var entry = await _employeeRepository.CreateEmployeeAsync(employee);
        
        EmployeeDto newEmployeeDto = new EmployeeDto(entry.EmployeeId, entry.Name);
        
        return newEmployeeDto;
    }
    
    
}