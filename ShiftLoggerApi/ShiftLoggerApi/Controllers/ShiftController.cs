using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Services.Interfaces;

namespace ShiftLoggerApi.Controllers;


[Route("api/[controller]")]
public class ShiftController : BaseController
{
    private readonly IShiftService _shiftService;
    
    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet("GetAllShifts")]
    public async Task<IActionResult> GetAllShiftsAsync()
    {
        try
        {
            List<ShiftDto> shiftsDto = await _shiftService.GetAllShiftsAsync();
            
            if (shiftsDto == null || !shiftsDto.Any())
            {
                return NotFound("No shifts found.");
            }
            
            return Ok(shiftsDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("GetShiftById/{id:int}")]
    public async Task<IActionResult> GetShiftByIdAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var shiftDto = await _shiftService.GetShiftByIdAsync(id);

            if (shiftDto == null)
            {
                return NotFound($"Shift with ID {id} was not found.");
            }

            return Ok(shiftDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpPost("CreateShift")]
    public async Task<IActionResult> CreateShiftAsync([FromBody] ShiftDto shiftDto)
    {
        try
        {
            if (shiftDto == null)
            {
                return BadRequest("Shift data is null.");
            }

            var createdShift = await _shiftService.CreateShiftAsync(shiftDto);
            return Ok(createdShift);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpPut("UpdateShiftById/{id:int}")]
    public async Task<IActionResult> UpdateShiftByIdAsync(int id, [FromBody] ShiftDto shiftDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            if (shiftDto == null)
            {
                return BadRequest("Shift data is null.");
            }

            var updatedShift = await _shiftService.UpdateShiftByIdAsync(id, shiftDto);
            
            if (updatedShift == null)
            {
                return NotFound($"Shift with ID {id} was not found.");
            }

            return Ok(updatedShift);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("DeleteShiftById/{id:int}")]
    public async Task<IActionResult> DeleteShiftByIdAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            await _shiftService.DeleteShiftByIdAsync(id);
            
            return Ok($"Shift with ID {id} has been deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet("GetShiftsByEmployeeId/{id:int}")]
    public async Task<IActionResult> GetShiftsByEmployeeIdAsync(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var shiftsDto = await _shiftService.GetShiftsByEmployeeIdAsync(id);
            
            if (shiftsDto == null || !shiftsDto.Any())
            {
                return NotFound($"No shifts found for employee with ID {id}.");
            }

            return Ok(shiftsDto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}