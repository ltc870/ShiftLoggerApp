using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;
using ShiftLoggerApi.Repositories.Interfaces;
using ShiftLoggerApi.Services.Interfaces;

namespace ShiftLoggerApi.Services;

public class ShiftService : IShiftService
{
    
    private readonly IShiftRepository _shiftRepository;
    
    public ShiftService(IShiftRepository shiftRepository)
    {
        _shiftRepository = shiftRepository;
    }
    
    public async Task<List<ShiftDto>> GetAllShiftsAsync()
    {
        List<Shift> shifts = await _shiftRepository.GetAllShiftsAsync();
        
        List<ShiftDto> shiftDtos = shifts.Select(shift => new ShiftDto(
            shift.ShiftId,
            shift.ShiftStart,
            shift.ShiftEnd,
            shift.EmployeeId)).ToList();
        
        return shiftDtos;
    }
    public async Task<ShiftDto?> GetShiftByIdAsync(int id)
    {
        var shift = await _shiftRepository.GetShiftByIdAsync(id);
        
        if (shift == null)
        {
            throw new KeyNotFoundException($"Shift with ID {id} not found.");
        }
        ShiftDto shiftDto = new ShiftDto(
            shift.ShiftId,
            shift.ShiftStart,
            shift.ShiftEnd,
            shift.EmployeeId);
        
        return shiftDto;
    }
    
    public async Task<ShiftDto> CreateShiftAsync(ShiftDto shiftDto)
    {
        Shift shift = new Shift
        {
            ShiftId = shiftDto.ShiftId,
            ShiftStart = shiftDto.ShiftStart,
            ShiftEnd = shiftDto.ShiftEnd,
            ShiftDuration = shiftDto.ShiftEnd - shiftDto.ShiftStart,
            EmployeeId = shiftDto.EmployeeId
        };
        
        var entry = await _shiftRepository.CreateShiftAsync(shift);
        
        return new ShiftDto(
            entry.ShiftId,
            entry.ShiftStart,
            entry.ShiftEnd,
            entry.EmployeeId);
    }
    
    public Task<ShiftDto> UpdateShiftAsync(ShiftDto shiftDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteShiftAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }
}