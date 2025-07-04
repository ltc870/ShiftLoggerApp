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
    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto)
    {
        Employee employee = new Employee
        {
            Name = employeeDto.Name,
        };
        
        await _employeeRepository.CreateEmployeeAsync(employee);
        return employeeDto;
    }
    
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        List<Employee> employees = await _employeeRepository.GetAllEmployeesAsync();
        List<EmployeeDto> employeeDtos = employees.Select(employee => new EmployeeDto(employee.Name)).ToList();
        return employeeDtos;

    }
}