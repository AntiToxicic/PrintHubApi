using PrintHub.Core.Dtos;

namespace PrintHub.Core.Interfaces.Services;

public interface IPrinterInstallationService
{
    public Task<PrinterInstallationDto?> Add(CreatePrinterInstallationDto printerInstallation);

    public Task<PrinterInstallationDto?> GetById(uint printerInstallationId);

    public Task<PrinterInstallationDto?> Update(PrinterInstallationDto printerInstallation);

    public Task Delete(uint printerInstallationId);
}