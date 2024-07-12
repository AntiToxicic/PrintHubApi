using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces;
using PrintHub.Core.Interfaces.Repositories;

namespace PrintHub.Infrastructure.Repositories;

public class PrinterInstallationRepository : IPrinterInstallationRepository
{
    private readonly MsSqlContext _context;

    public PrinterInstallationRepository(MsSqlContext context)
    {
        _context = context;
    }

    public async Task<PrinterInstallation?> Add(PrinterInstallation printerInstallation)
    {
        _context.PrinterInstallations.Add(printerInstallation);
        await _context.SaveChangesAsync();

        return printerInstallation;
    }

    public Task<PrinterInstallation?> GetById(uint printerInstallationId) =>
        _context.PrinterInstallations.FirstOrDefaultAsync(c => c.Id == printerInstallationId);

    public async Task<PrinterInstallation?> Update(PrinterInstallation printerInstallation)
    {
        _context.PrinterInstallations.Update(printerInstallation);
        await _context.SaveChangesAsync();

        return printerInstallation;
    }

    public Task Delete(PrinterInstallation printerInstallation)
    {
        _context.PrinterInstallations.Remove(printerInstallation);
        return _context.SaveChangesAsync();
    }
}