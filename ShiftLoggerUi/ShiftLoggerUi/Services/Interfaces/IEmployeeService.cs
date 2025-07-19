using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Services.Interfaces;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync();
    Task<EmployeeDto> CreateEmployeeAsync();
    Task<EmployeeDto> UpdateEmployeeByIdAsync();
    Task<bool> DeleteEmployeeByIdAsync();
}