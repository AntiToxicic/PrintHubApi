using PrintHub.Core.Entities;

namespace PrintHub.Core.Interfaces.Repositories;

public interface IPrintJobRepository
{
    public Task<PrintJob?> Add(PrintJob printerJob);
    
    public Task<PrintJob?> GetById(uint printJobId);
    
    public Task<PrintJob?> Update(PrintJob printerJob);
    
    public Task Delete(PrintJob printerJob);
}