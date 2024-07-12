using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;

namespace PrintHub.Core.Services;

public class PrintJobService : IPrintJobService
{
    private readonly IPrintJobRepository _printJobRepository;

    public PrintJobService(IPrintJobRepository printJobRepository)
    {
        _printJobRepository = printJobRepository;
    }

    public async Task<PrintJobDto?> Add(CreatePrintJobDto printerJobDto)
    {
        var printJob = new PrintJob(printerJobDto.Name, printerJobDto.PageCount, printerJobDto.IsSuccess);
        printJob = await _printJobRepository.Add(printJob);

        if (printJob is null) return null;

        return new PrintJobDto(
            printJob.Id,
            printJob.Name,
            printJob.PageCount,
            printJob.IsSuccess,
            printJob.EmployeeId,
            printJob.PrinterInstallationId);
    }

    public async Task<PrintJobDto?> GetById(uint printJobId)
    {
        var printJob = await _printJobRepository.GetById(printJobId);

        if (printJob is null) return null;

        return new PrintJobDto(
            printJob.Id,
            printJob.Name,
            printJob.PageCount,
            printJob.IsSuccess,
            printJob.EmployeeId,
            printJob.PrinterInstallationId);
    }

    public async Task<PrintJobDto?> Update(PrintJobDto printerJobDto)
    {
        var printJob = new PrintJob(printerJobDto.Name, printerJobDto.PageCount, printerJobDto.IsSuccess);
        printJob = await _printJobRepository.Update(printJob);

        if (printJob is null) return null;

        return new PrintJobDto(
            printJob.Id,
            printJob.Name,
            printJob.PageCount,
            printJob.IsSuccess,
            printJob.EmployeeId,
            printJob.PrinterInstallationId);
    }

    public async Task Delete(uint printJobId)
    {
        var printJob = await _printJobRepository.GetById(printJobId);

        if (printJob is null) return;
        
        await _printJobRepository.Delete(printJob);
    }
}