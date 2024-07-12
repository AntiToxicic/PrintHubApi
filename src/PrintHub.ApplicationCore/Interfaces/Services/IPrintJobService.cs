using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;

namespace PrintHub.Core.Interfaces.Services;

public interface IPrintJobService
{
    public Task<PrintJobDto?> Add(CreatePrintJobDto printerJobDto);
    
    public Task<PrintJobDto?> GetById(uint printJobId);
    
    public Task<PrintJobDto?> Update(PrintJobDto printerJobDto);
    
    public Task Delete(uint printJobId);
}