using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

[ApiController]
[Route("api/employees")]
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
            return StatusCode(StatusCodes.Status500InternalServerError, "Работник не создан");

        return CreatedAtAction(nameof(GetEmployee), 
            new { employeeId = employeeDto.Id }, employeeDto);
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> GetEmployee(uint employeeId)
    {
        var employeeDto = await _employeeService.GetById(employeeId);

        if (employeeDto is null)
            return NotFound();

        return Ok(employeeDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedEmployeeDto = await _employeeService.Update(employeeDto);

        if (updatedEmployeeDto is null)
            return NotFound();

        return Ok(updatedEmployeeDto);
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(uint employeeId)
    {
        await _employeeService.Delete(employeeId);

        return NoContent();
    }
}