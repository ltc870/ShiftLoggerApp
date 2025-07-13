using System.Net.Http.Json;
using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class EmployeeService : IEmployeeService
{

    public EmployeeService()
    {
        
    }
    
    public Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto> CreateEmployeeAsync()
    {
        Console.Clear();
        Console.WriteLine("Create a new employee!");
        Console.WriteLine("<-------------------------------------------->");
        Console.Write("Enter employee name: ");
        string? employeeName = Console.ReadLine();
        EmployeeDto newEmployee = new EmployeeDto(employeeName);

        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:7145/");
        HttpResponseMessage response = await client.PostAsJsonAsync("api/Employee/CreateEmployee", newEmployee);
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

    public Task<EmployeeDto> UpdateEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }
}