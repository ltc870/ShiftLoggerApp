using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class ShiftService : IShiftService
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

    public Task<ShiftDto> GetShiftByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShiftDto> CreateShiftAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShiftDto> UpdateShiftByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShiftByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync()
    {
        throw new NotImplementedException();
    }
    
}