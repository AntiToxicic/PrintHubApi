using PrintHub.Core.Dtos;

namespace PrintHub.Core.Interfaces.Services;

public interface IPrinterService
{
    public Task<PrinterDto?> Add(CreatePrinterDto printer);
    
    public Task<PrinterDto?> GetById(uint printerId);
    
    public Task<PrinterDto?> Update(PrinterDto printer);
    
    public Task Delete(uint printerId);
}