using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;
using PrintHub.Core.Enums;
using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;

namespace PrintHub.Core.Services;

public class PrinterService : IPrinterService
{
    private readonly IPrinterRepository _printerRepository;

    public PrinterService(IPrinterRepository printerRepository)
    {
        _printerRepository = printerRepository;
    }

    public async Task<PrinterDto?> Add(CreatePrinterDto printerDto)
    {
        var printer = new Printer(printerDto.Name, printerDto.ConnectionType, printerDto.MacAddress);
        printer = await _printerRepository.Add(printer);

        if (printer is null) return null;

        if (printer.MacAddress is not null && printer.MacAddress.Length != 17)
            return null;

        return new PrinterDto(printer.Id, printer.Name, printer.ConnectionType, printer.MacAddress);
    }

    public async Task<PrinterDto?> GetById(uint printerId)
    {
        var printer = await _printerRepository.GetById(printerId);

        if (printer is null) return null;

        return new PrinterDto(printer.Id, printer.Name, printer.ConnectionType, printer.MacAddress);
    }

    public async Task<PrinterDto?> Update(PrinterDto printerDto)
    {
        var printer = new Printer(printerDto.Name, printerDto.ConnectionType, printerDto.MacAddress);
        printer = await _printerRepository.Update(printer);

        if (printer is null) return null;

        return new PrinterDto(printer.Id, printer.Name, printer.ConnectionType, printer.MacAddress);
    }

    public async Task Delete(uint printerId)
    {
        var printer = await _printerRepository.GetById(printerId);

        if (printer is null) return;

        await _printerRepository.Delete(printer);
    }

    public async Task<IReadOnlyCollection<PrinterDto>> GetAll(ConnectionType? connectionType)
    {
        var printers = await _printerRepository.GetAll(connectionType);
        var printersDtos = new List<PrinterDto>();

        foreach (var printer in printers)
        {
            printersDtos.Add(new PrinterDto(printer.Id, printer.Name, printer.ConnectionType, printer.MacAddress));
        }

        return printersDtos;
    }
}