using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Models;
using ShiftLoggerApi.Services;
using ShiftLoggerApi.Services.Interfaces;

namespace ShiftLoggerApi.Controllers;

[Route("api/[controller]")]
public class EmployeeController : BaseController
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        try
        {
            List<EmployeeDto> employeeDto = await _employeeService.GetAllEmployeesAsync();
            return Ok(employeeDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            await _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(employeeDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}