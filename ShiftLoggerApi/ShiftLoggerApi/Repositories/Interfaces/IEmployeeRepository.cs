using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<EntityEntry<Employee>> CreateEmployeeAsync(Employee employee);
    Task<List<Employee>> GetAllEmployeesAsync();
}