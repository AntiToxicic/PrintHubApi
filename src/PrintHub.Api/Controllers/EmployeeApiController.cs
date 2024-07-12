using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

public class EmployeeApiController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeApiController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employeeDto = await _employeeService.Add(createEmployeeDto);

        if (employeeDto is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Работник не был создан");
        
        return Ok(employeeDto);
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployee(uint employeeId)
    {
        
        
        return Ok();
    }
}