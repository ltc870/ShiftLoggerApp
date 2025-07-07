using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IShiftRepository
{
    Task<List<Shift>> GetAllShiftsAsync();
    Task<Shift?> GetShiftByIdAsync(int shiftId);
    Task<Shift> CreateShiftAsync(Shift shift);
    Task<Shift> UpdateShiftAsync(Shift shift);
    Task<bool> DeleteShiftAsync(int shiftId);
    Task<List<Shift>> GetShiftsByEmployeeIdAsync(int employeeId);
}