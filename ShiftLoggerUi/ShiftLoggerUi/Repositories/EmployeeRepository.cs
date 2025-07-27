using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{

    private readonly HttpClient _httpClient;
    
    public EmployeeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
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

    public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/Employee/GetEmployeeById/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<EmployeeDto>();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error fetching employee by ID: {response.StatusCode} - {error}");
            return null;
        }

    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
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

    public async Task<EmployeeDto> UpdateEmployeeByIdAsync(int id, EmployeeDto employee)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Employee/UpdateEmployeeById/{id}", employee);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Employee updated successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return await response.Content.ReadFromJsonAsync<EmployeeDto>();
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error updating employee: {response.StatusCode} - {error}");
            return null;
        }
    }

    public async Task<bool> DeleteEmployeeByIdAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Employee/DeleteEmployeeById/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Employee deleted successfully");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return true;
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error deleting employee: {response.StatusCode} - {error}");
            throw new Exception("Failed to delete employee");
        }
    }
}