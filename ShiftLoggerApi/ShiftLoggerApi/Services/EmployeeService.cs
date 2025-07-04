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
}