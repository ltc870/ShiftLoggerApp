using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> CreateEmployeeAsync(Employee employee);
}