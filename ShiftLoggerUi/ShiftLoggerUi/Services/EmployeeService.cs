using ShiftLoggerUi.Dtos;
using ShiftLoggerUi.Services.Interfaces;

namespace ShiftLoggerUi.Services;

public class EmployeeService : IEmployeeService
{
    public Task<List<EmployeeDto>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> GetEmployeeByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDto> CreateEmployeeAsync()
    {
        throw new NotImplementedException();
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