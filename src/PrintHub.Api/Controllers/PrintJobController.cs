using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

[ApiController]
[Route("api/printjobs")]
public class PrintJobController : ControllerBase
{
    private readonly IPrintJobService _printJobService;

    public PrintJobController(IPrintJobService printJobService)
    {
        _printJobService = printJobService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrintJob([FromBody] CreatePrintJobDto createPrintJobDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var printJobDto = await _printJobService.Add(createPrintJobDto);
        
        if(printJobDto is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Инсталяция не создана");

        return CreatedAtAction(nameof(GetPrintJob),
            new { printJobId = printJobDto.Id }, printJobDto);
    }

    [HttpGet("{printJobId}")]
    public async Task<IActionResult> GetPrintJob(uint printJobId)
    {
        var printJobDto = await _printJobService.GetById(printJobId);

        if (printJobDto is null)
            return NotFound();

        return Ok(printJobDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePrintJob([FromBody] PrintJobDto printJobDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedPrintJobDto = await _printJobService.Update(printJobDto);

        if (updatedPrintJobDto is null)
            return NotFound();

        return Ok(updatedPrintJobDto);
    }

    [HttpDelete("{printJobId}")]
    public async Task<IActionResult> DeletePrintJob(uint printJobId)
    {
        await _printJobService.Delete(printJobId);

        return NoContent();
    }
    
}