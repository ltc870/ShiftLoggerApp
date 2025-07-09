using ShiftLoggerApi.Models;

namespace ShiftLoggerApi.Repositories.Interfaces;

public interface IShiftRepository
{
    Task<List<Shift>> GetAllShiftsAsync();
    Task<Shift> GetShiftByIdAsync(int shiftId);
    Task<Shift> CreateShiftAsync(Shift shift);
    Task<Shift> UpdateShiftByIdAsync(int id, Shift shift);
    Task DeleteShiftByIdAsync(int id);
    Task<List<Shift>> GetShiftsByEmployeeIdAsync(int employeeId);
}