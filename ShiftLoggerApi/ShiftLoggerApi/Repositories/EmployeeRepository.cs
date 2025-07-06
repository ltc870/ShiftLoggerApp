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
    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            return await _dbContext.Employees.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        try
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        try
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return employee;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Employee> UpdateEmployeeByIdAsync(int id, Employee employee)
    {
        try
        {
            var employeeToUpdate = await _dbContext.Employees.FindAsync(id);
            
            if (employeeToUpdate == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            
            employeeToUpdate.Name = employee.Name;

            await _dbContext.SaveChangesAsync();
            return employeeToUpdate;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteEmployeeByIdAsync(int id)
    {
        try
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}