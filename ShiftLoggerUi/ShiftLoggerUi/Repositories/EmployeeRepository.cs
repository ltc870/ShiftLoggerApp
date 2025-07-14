using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly HttpClient _httpClient;
    
    public EmployeeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7145/");
    }
    
    public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        var response = await _httpClient.GetAsync("api/Employee/GetAllEmployees");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<EmployeeDto>>() ?? new List<EmployeeDto>();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error fetching employees: {response.StatusCode} - {error}");
            return new List<EmployeeDto>();
        }
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Employee created successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await response.Content.ReadFromJsonAsync<EmployeeDto>();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error creating employee: {response.StatusCode} - {error}");
            return null;
        }
    }

    public Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, EmployeeDto employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}