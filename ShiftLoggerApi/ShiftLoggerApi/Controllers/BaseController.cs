using Microsoft.AspNetCore.Mvc;

namespace ShiftLoggerApi.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult HandleError(Exception ex)
    {
        return StatusCode(500, new { Message = "An error occurred", Details = ex.Message });
    }
}