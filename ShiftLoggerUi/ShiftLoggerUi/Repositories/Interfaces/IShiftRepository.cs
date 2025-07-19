using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public interface IShiftRepository
{
    Task<List<ShiftDto>> GetAllShiftsAsync();
    Task<ShiftDto> GetShiftByIdAsync(int shiftId);
    Task<ShiftDto> CreateShiftAsync(ShiftDto shift);
    Task<ShiftDto> UpdateShiftByIdAsync(int shiftId, ShiftDto shiftDto);
    Task<bool> DeleteShiftByIdAsync(int shiftId);
    Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId);
}