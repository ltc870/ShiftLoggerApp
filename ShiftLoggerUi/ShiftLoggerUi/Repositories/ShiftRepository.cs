using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public class ShiftRepository : IShiftRepository
{
    private readonly HttpClient _httpClient;
    
    public ShiftRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ShiftDto>> GetAllShiftsAsync()
    {
        var response = await _httpClient.GetAsync("api/Shift/GetAllShifts");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<ShiftDto>>() ?? new List<ShiftDto>();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error fetching shifts: {response.StatusCode} - {error}");
            return new List<ShiftDto>();
        }
    }

    public Task<ShiftDto> GetShiftByIdAsync(int shiftId)
    {
        throw new NotImplementedException();
    }

    public async Task<ShiftDto> CreateShiftAsync(ShiftDto shift)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Shift/CreateShift", shift);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Shift created successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await response.Content.ReadFromJsonAsync<ShiftDto>() ;
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error creating shift: {response.StatusCode} - {error}");
            return null;
        }
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