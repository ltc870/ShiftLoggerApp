using System.Globalization;
using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Repositories;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class ShiftService : IShiftService
{
    private readonly IEmployeeService _employeeService;
    private readonly IShiftRepository _shiftRepository;
    
    public ShiftService(IEmployeeService employeeService, IShiftRepository shiftRepository)
    {
        _employeeService = employeeService;
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

    public async Task<ShiftDto> CreateShiftAsync()
    {
        Console.Clear();
        Console.WriteLine("Creating a new shift...");
        await _employeeService.GetAllEmployeesAsync();
        Console.WriteLine("Please enter the Employee ID for the shift...");
        int employeeId;
        
        while (!int.TryParse(Console.ReadLine(), out employeeId))
        {
            Console.WriteLine("Invalid input. Please enter a valid Employee ID.");
        }
        
        Console.WriteLine("Please enter the date of the shift (yyyy-MM-dd):");
        DateTime date;
        while (!DateTime.TryParseExact(Console.ReadLine()?.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
        {
            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
        }
        
        Console.WriteLine("Please enter the start time of the shift (HH:mm):");
        TimeSpan startTime;
        while (!TimeSpan.TryParseExact(Console.ReadLine(), @"hh\:mm", CultureInfo.InvariantCulture, out startTime))
        {
            Console.WriteLine("Invalid time format. Please enter a valid time (HH:mm).");
        }

        Console.WriteLine("Please enter the end time of the shift (HH:mm):");
        TimeSpan endTime;
        while (!TimeSpan.TryParseExact(Console.ReadLine(), @"hh\:mm", CultureInfo.InvariantCulture, out endTime))
        {
            Console.WriteLine("Invalid time format. Please enter a valid time (HH:mm).");
        }
        

        ShiftDto shift = new ShiftDto(date, startTime, endTime, employeeId);
        
        var createdShift = await _shiftRepository.CreateShiftAsync(shift);
        if (createdShift == null)
        {
            Console.WriteLine("Failed to create the shift. Please try again.");
            return null;
        }

        return createdShift;

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