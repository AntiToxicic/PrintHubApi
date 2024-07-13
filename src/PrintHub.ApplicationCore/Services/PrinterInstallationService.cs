using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;

namespace PrintHub.Core.Services;

public class PrinterInstallationService : IPrinterInstallationService
{
    private readonly IPrinterInstallationRepository _installationRepository;

    public PrinterInstallationService(IPrinterInstallationRepository installationRepository)
    {
        _installationRepository = installationRepository;
    }

    public async Task<PrinterInstallationDto?> Add(CreatePrinterInstallationDto printerInstallationDto)
    {
        var printerInstallation = new PrinterInstallation(
            printerInstallationDto.InternalName,
            printerInstallationDto.InternalSerialNumber,
            printerInstallationDto.IsDefault,
            printerInstallationDto.PrinterId,
            printerInstallationDto.BranchId);

        printerInstallation = await _installationRepository.Add(printerInstallation);

        if (printerInstallation is null) return null;

        return new PrinterInstallationDto(
            printerInstallation.Id,
            printerInstallation.InternalName,
            printerInstallation.InternalSerialNumber,
            printerInstallation.IsDefault,
            printerInstallation.PrinterId,
            printerInstallation.BranchId);
    }

    public async Task<PrinterInstallationDto?> GetById(uint printerInstallationId)
    {
        var printerInstallation = await _installationRepository.GetById(printerInstallationId);

        if (printerInstallation is null) return null;

        return new PrinterInstallationDto(
            printerInstallation.Id,
            printerInstallation.InternalName,
            printerInstallation.InternalSerialNumber,
            printerInstallation.IsDefault,
            printerInstallation.PrinterId,
            printerInstallation.BranchId);
    }

    public async Task<PrinterInstallationDto?> Update(PrinterInstallationDto printerInstallationDto)
    {
        var printerInstallation = new PrinterInstallation(
            printerInstallationDto.InternalName,
            printerInstallationDto.InternalSerialNumber,
            printerInstallationDto.IsDefault,
            printerInstallationDto.PrinterId,
            printerInstallationDto.BranchId);

        printerInstallation = await _installationRepository.Update(printerInstallation);

        if (printerInstallation is null) return null;

        printerInstallationDto.Id = printerInstallation.Id;

        return printerInstallationDto;
    }

    public async Task Delete(uint printerInstallationId)
    {
        var printerInstallation = await _installationRepository.GetById(printerInstallationId);

        if (printerInstallation is null) return;

        await _installationRepository.Delete(printerInstallation);
    }
}