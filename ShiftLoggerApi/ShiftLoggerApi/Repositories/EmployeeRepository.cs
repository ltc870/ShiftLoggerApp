using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShiftLoggerApi.Data;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;
using ShiftLoggerApi.Repositories.Interfaces;

namespace ShiftLoggerApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDBContext _dbContext;
    public EmployeeRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<EntityEntry<Employee>> CreateEmployeeAsync(Employee employee)
    {
        try
        {
            var entry = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return entry;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<List<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            return _dbContext.Employees.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}