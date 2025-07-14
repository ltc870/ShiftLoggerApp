using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;

namespace ShiftLoggerUi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    public Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employee)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7145/");
        HttpResponseMessage response = await client.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
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