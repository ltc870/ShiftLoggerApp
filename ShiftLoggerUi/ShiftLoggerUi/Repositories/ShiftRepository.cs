using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly HttpClient _httpClient;
    
    public ShiftRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7145/");
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