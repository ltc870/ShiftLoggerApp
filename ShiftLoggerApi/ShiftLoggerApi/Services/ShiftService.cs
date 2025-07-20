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
            shift.Date,
            shift.ShiftStart,
            shift.ShiftEnd,
            shift.EmployeeId)).ToList();
        
        return shiftDtos;
    }
    
    public async Task<ShiftDto> GetShiftByIdAsync(int id)
    {
        var shift = await _shiftRepository.GetShiftByIdAsync(id);
        
        if (shift == null)
        {
            throw new KeyNotFoundException($"Shift with ID {id} not found.");
        }
        ShiftDto shiftDto = new ShiftDto(
            shift.ShiftId,
            shift.Date,
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
            entry.Date,
            entry.ShiftStart,
            entry.ShiftEnd,
            entry.EmployeeId);
    }
    
    public async Task<ShiftDto> UpdateShiftByIdAsync(int id, ShiftDto shiftDto)
    {
        try
        {
            Shift shift = new Shift()
            {
                EmployeeId = id,
                ShiftStart = shiftDto.ShiftStart,
                ShiftEnd = shiftDto.ShiftEnd,
                ShiftDuration = shiftDto.ShiftEnd - shiftDto.ShiftStart,
                ShiftId = shiftDto.ShiftId
            };

            var updatedShift = await _shiftRepository.UpdateShiftByIdAsync(id, shift);
            
            if (updatedShift == null)
            {
                throw new KeyNotFoundException($"Shift with ID {id} not found.");
            }
            
            ShiftDto updatedShiftDto = new ShiftDto(
                updatedShift.ShiftId,
                updatedShift.Date,
                updatedShift.ShiftStart,
                updatedShift.ShiftEnd,
                updatedShift.EmployeeId);

            return updatedShiftDto;
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
            await _shiftRepository.DeleteShiftByIdAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<ShiftDto>> GetShiftsByEmployeeIdAsync(int employeeId)
    {
        try
        {
            var shifts = await _shiftRepository.GetShiftsByEmployeeIdAsync(employeeId);
            
            if (shifts == null || !shifts.Any())
            {
                throw new KeyNotFoundException($"No shifts found for employee with ID {employeeId}.");
            }
            
            List<ShiftDto> shiftDtos = shifts.Select(shift => new ShiftDto(
                shift.ShiftId,
                shift.Date,
                shift.ShiftStart,
                shift.ShiftEnd,
                shift.EmployeeId)).ToList();

            return shiftDtos;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}