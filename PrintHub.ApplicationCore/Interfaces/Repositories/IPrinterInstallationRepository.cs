using PrintHub.Core.Entities;

namespace PrintHub.Core.Interfaces.Repositories;

public interface IPrinterInstallationRepository
{
    public Task<PrinterInstallation?> Add(PrinterInstallation printerInstallation);
    
    public Task<PrinterInstallation?> GetById(uint printerInstallationId);
    
    public Task<PrinterInstallation?> Update(PrinterInstallation printerInstallation);
    
    public Task Delete(PrinterInstallation printerInstallation);
}