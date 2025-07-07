using Microsoft.EntityFrameworkCore;
using ShiftLoggerApi.Data;
using ShiftLoggerApi.Models;
using ShiftLoggerApi.Repositories.Interfaces;

namespace ShiftLoggerApi.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly ApplicationDBContext _dbContext;
    
    public ShiftRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Shift>> GetAllShiftsAsync()
    {
        try
        {
            return await _dbContext.Shifts.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Shift?> GetShiftByIdAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public async Task<Shift> CreateShiftAsync(Shift shift)
    {
        try
        {
            await _dbContext.Shifts.AddAsync(shift);
            await _dbContext.SaveChangesAsync();
            return shift;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<Shift> UpdateShiftAsync(Shift shift)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShiftAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Shift>> GetShiftsByEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }
}