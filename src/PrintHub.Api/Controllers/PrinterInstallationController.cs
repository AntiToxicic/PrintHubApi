using Microsoft.AspNetCore.Mvc;
using PrintHub.Core.Dtos;
using PrintHub.Core.Interfaces.Services;

namespace PrintHubAPI.Controllers;

[ApiController]
[Route("api/printerInstallations")]
public class PrinterInstallationController : ControllerBase
{
    private readonly IPrinterInstallationService _installationService;

    public PrinterInstallationController(IPrinterInstallationService installationService)
    {
        _installationService = installationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrinterInstallation(
        [FromBody] CreatePrinterInstallationDto createPrinterInstallationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var printerInstallationDto = await _installationService.Add(createPrinterInstallationDto);

        if (printerInstallationDto is null)
            return StatusCode(StatusCodes.Status500InternalServerError, "Инсталяция не создана");

        return CreatedAtAction(nameof(GetPrinterInstallation),
            new { printerInstallationId = printerInstallationDto.Id }, printerInstallationDto);
    }

    [HttpGet("{printerInstallationId}")]
    public async Task<IActionResult> GetPrinterInstallation(uint printerInstallationId)
    {
        var printerInstallationDto = await _installationService.GetById(printerInstallationId);

        if (printerInstallationDto is null)
            return NotFound();

        return Ok(printerInstallationDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePrinterInstallation(
        [FromBody] PrinterInstallationDto printerInstallationDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updatedInstallation = await _installationService.Update(printerInstallationDto);

        if (updatedInstallation is null)
            return NotFound();

        return Ok(updatedInstallation);
    }

    [HttpDelete("{printerInstallationId}")]
    public async Task<IActionResult> DeletePrinterInstallation(uint printerInstallationId)
    {
        await _installationService.Delete(printerInstallationId);

        return NoContent();
    }
}