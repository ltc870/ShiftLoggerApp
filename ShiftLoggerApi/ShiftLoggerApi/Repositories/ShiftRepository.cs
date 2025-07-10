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

    public async Task<Shift> GetShiftByIdAsync(int id)
    {
        try
        {
            var shift = await _dbContext.Shifts.FindAsync(id);
            
            if (shift == null)
            {
                throw new KeyNotFoundException($"Shift with ID {id} not found.");
            }
            
            return shift;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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

    public async Task<Shift> UpdateShiftByIdAsync(int id, Shift shift)
    {
        try
        {
            var existingShift = _dbContext.Shifts.Find(id);
            
            if (existingShift == null)
            {
                throw new KeyNotFoundException($"Shift with ID {id} not found.");
            }
            
            existingShift.ShiftStart = shift.ShiftStart;
            existingShift.ShiftEnd = shift.ShiftEnd;
            existingShift.ShiftDuration = shift.ShiftEnd - shift.ShiftStart;
            existingShift.EmployeeId = shift.EmployeeId;
            
            await _dbContext.SaveChangesAsync();
            return existingShift;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteShiftByIdAsync(int id)
    {
        try
        {
            var shift = await _dbContext.Shifts.FirstOrDefaultAsync(shift => shift.ShiftId == id);

            if (shift == null)
            {
                throw new KeyNotFoundException($"Shift with ID {id} not found.");
            }

            _dbContext.Shifts.Remove(shift);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Shift>> GetShiftsByEmployeeIdAsync(int employeeId)
    {
        try
        {
            var shifts = _dbContext.Shifts.Where(shift => shift.EmployeeId == employeeId);

            if (shifts == null)
            {
                throw new KeyNotFoundException($"Shifts with EmployeeId {employeeId} not found.");
            }

            return await shifts.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}