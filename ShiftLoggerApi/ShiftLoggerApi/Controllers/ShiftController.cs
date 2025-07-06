using Microsoft.AspNetCore.Mvc;
using ShiftLoggerApi.Dtos;
using ShiftLoggerApi.Services.Interfaces;

namespace ShiftLoggerApi.Controllers;


[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class ShiftController : BaseController
{
    private readonly IShiftService _service;
    
    public ShiftController(IShiftService service)
    {
        _service = service;
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

            var createdShift = await _service.CreateShiftAsync(shiftDto);
            return Ok(createdShift);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500, "Internal server error");
        }
    }
}