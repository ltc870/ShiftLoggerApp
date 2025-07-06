using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> CreateEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeByIdAsync(int id, Employee employee);
    Task DeleteEmployeeByIdAsync(int id);
}