using ShiftLoggerApi.Dtos;

namespace ShiftLoggerApi.Services.Interfaces;

public interface IShiftService
{
    Task<List<ShiftDto>> GetAllShiftsAsync();
    Task<ShiftDto?> GetShiftByIdAsync(int shiftId);
    Task<ShiftDto> CreateShiftAsync(ShiftDto shiftDto);
    Task<ShiftDto> UpdateShiftAsync(ShiftDto shiftDto);
    Task<bool> DeleteShiftAsync(int shiftId);
    Task<IEnumerable<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId);
}