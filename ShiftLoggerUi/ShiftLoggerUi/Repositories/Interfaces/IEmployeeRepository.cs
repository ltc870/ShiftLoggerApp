using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public interface IEmployeeRepository
{
    Task<List<EmployeeDto>> GetAllEmployeesAsync();
    Task<EmployeeDto> GetEmployeeByIdAsync(int id);
    Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee);
    Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, EmployeeDto employee);
    Task<bool> DeleteEmployeeByIdAsync(int id);
}