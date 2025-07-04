using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Services.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
}