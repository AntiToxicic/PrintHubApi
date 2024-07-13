namespace PrintHub.Core.Dtos;

public class CreatePrinterInstallationDto
{
    public CreatePrinterInstallationDto(string internalName, int? internalSerialNumber, bool isDefault, uint printerId, uint branchId)
    {
        InternalName = internalName;
        InternalSerialNumber = internalSerialNumber;
        IsDefault = isDefault;
        PrinterId = printerId;
        BranchId = branchId;
    }
    
    public string InternalName { get; set; }
    
    public int? InternalSerialNumber { get; set; }
    
    public bool IsDefault { get; set; }
    
    public uint PrinterId { get; set; }
    
    public uint BranchId { get; set; }
}