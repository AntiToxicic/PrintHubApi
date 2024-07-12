using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces;
using PrintHub.Core.Interfaces.Repositories;

namespace PrintHub.Infrastructure.Repositories;

public class PrinterRepository : IPrinterRepository
{
    private readonly MsSqlContext _context;

    public PrinterRepository(MsSqlContext context)
    {
        _context = context;
    }

    public async Task<Printer?> Add(Printer printer)
    {
        _context.Printers.Add(printer);
        await _context.SaveChangesAsync();
        
        return printer;
    }

    public Task<Printer?> GetById(uint printerId) =>
        _context.Printers.FirstOrDefaultAsync(c => c.Id == printerId);

    public async Task<Printer?> Update(Printer printer)
    {
        _context.Printers.Update(printer);
        await _context.SaveChangesAsync();

        return printer;
    }

    public Task Delete(Printer printer)
    {
        _context.Printers.Remove(printer);
        return _context.SaveChangesAsync();
    }
}