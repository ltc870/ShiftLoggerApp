using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class ShiftService : IShfitService
{
    private readonly IShiftRepository _shiftRepository;
    
    public ShiftService(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }

    public Task<List<ShiftDto>> GetAllShiftsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShiftDto> GetShiftByIdAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public Task<ShiftDto> CreateShiftAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShiftDto> UpdateShiftByIdAsync(int shiftId, ShiftDto shiftDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShiftByIdAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }
}