using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces;
using PrintHub.Core.Interfaces.Repositories;

namespace PrintHub.Infrastructure.Repositories;

public class PrintJobRepository : IPrintJobRepository
{
    private readonly MsSqlContext _context;

    public PrintJobRepository(MsSqlContext context)
    {
        _context = context;
    }

    public async Task<PrintJob?> Add(PrintJob printerJob)
    {
        _context.PrintJobs.Add(printerJob);
        await _context.SaveChangesAsync();
        return printerJob;
    }

    public Task<PrintJob?> GetById(uint printJobId) =>
        _context.PrintJobs.FirstOrDefaultAsync(c => c.Id == printJobId);

    public async Task<PrintJob?> Update(PrintJob printerJob)
    {
        _context.PrintJobs.Update(printerJob);
        await _context.SaveChangesAsync();
        return printerJob;
    }

    public Task Delete(PrintJob printerJob)
    {
        _context.PrintJobs.Remove(printerJob);
        return _context.SaveChangesAsync();
    }
}