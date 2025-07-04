using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task CreateEmployeeAsync(Employee employee);
    Task<List<Employee>> GetAllEmployeesAsync();
}