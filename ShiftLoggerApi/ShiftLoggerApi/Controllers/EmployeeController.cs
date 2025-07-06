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

    [HttpGet("GetAllEmployees")]
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        try
        {
            List<EmployeeDto> employeeDto = await _employeeService.GetAllEmployeesAsync();
            
            if (!employeeDto.Any())
            {
                return NotFound("No employees found.");
            }
            
            return Ok(employeeDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpGet("GetEmployeeById/{id:int}")]
    public async Task<IActionResult> GetEmployeeByIdAsync(int id)
    {
        try
        {
            var employeeDto = await _employeeService.GetEmployeeByIdAsync(id);
            
            if (employeeDto == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            
            return Ok(employeeDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost("CreateEmployee")]
    public async Task<IActionResult> CreateEmployeeAsync([FromBody] EmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(createdEmployee);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [HttpPut("UpdateEmployee/{id:int}")]
    public async Task<IActionResult> UpdateEmployeeByIdAsync(int id, [FromBody] EmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var updatedEmployee = await_employeeService.UpdateEmployeeAsync(id, employeeDto);
            if (updatedEmployee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(updatedEmployee);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}