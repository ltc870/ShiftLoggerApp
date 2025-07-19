using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Services.Interfaces;

public interface IShiftService
{
    Task<List<ShiftDto>> GetAllShiftsAsync();
    Task<ShiftDto> GetShiftByIdAsync();
    Task<ShiftDto> CreateShiftAsync();
    Task<ShiftDto> UpdateShiftByIdAsync();
    Task<bool> DeleteShiftByIdAsync();
    Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync();
}