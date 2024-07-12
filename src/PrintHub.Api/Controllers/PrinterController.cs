using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

[ApiController]
[Route("api/printers")]
public class PrinterController : ControllerBase
{
    private readonly IPrinterService _printerService;

    public PrinterController(IPrinterService printerService)
    {
        _printerService = printerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrinter([FromBody] CreatePrinterDto createPrinterDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var printerDto = await _printerService.Add(createPrinterDto);

        if (printerDto is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Принтер не создан");

        return CreatedAtAction(nameof(GetPrinter),
            new { printerId = printerDto.Id }, printerDto);
    }

    [HttpGet("{printerId}")]
    public async Task<IActionResult> GetPrinter(uint printerId)
    {
        var printerDto = await _printerService.GetById(printerId);

        if (printerDto is null)
            return NotFound();

        return Ok(printerDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePrinter([FromBody] PrinterDto printerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedPrinterDto = await _printerService.Update(printerDto);

        if (updatedPrinterDto is null)
            return NotFound();

        return Ok(updatedPrinterDto);
    }

    [HttpDelete("{printerId}")]
    public async Task<IActionResult> DeletePrinter(uint printerId)
    {
        await _printerService.Delete(printerId);

        return NoContent();
    }
}