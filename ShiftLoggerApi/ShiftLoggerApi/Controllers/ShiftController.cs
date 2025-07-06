using Microsoft.AspNetCore.Mvc;
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
}