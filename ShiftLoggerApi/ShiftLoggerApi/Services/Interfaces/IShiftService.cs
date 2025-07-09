using ShiftLoggerApi.Dtos;

namespace ShiftLoggerApi.Services.Interfaces;

public interface IShiftService
{
    Task<List<ShiftDto>> GetAllShiftsAsync();
    Task<ShiftDto?> GetShiftByIdAsync(int shiftId);
    Task<ShiftDto> CreateShiftAsync(ShiftDto shiftDto);
    Task<ShiftDto> UpdateShiftByIdAsync(int id, ShiftDto shiftDto);
    Task DeleteShiftByIdAsync(int shiftId);
    Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId);
}