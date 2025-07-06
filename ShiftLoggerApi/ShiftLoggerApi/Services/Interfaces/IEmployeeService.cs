using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto);
    Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, EmployeeDto employeeDto);
    Task DeleteEmployeeByIdAsync(int id);
}