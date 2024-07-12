namespace PrintHub.Core.Dtos;

public class PrinterInstallationDto
{
    public PrinterInstallationDto(uint id, string internalName, int internalSerialNumber, bool isDefault, uint printerId, uint branchId)
    {
        Id = id;
        InternalName = internalName;
        InternalSerialNumber = internalSerialNumber;
        IsDefault = isDefault;
        PrinterId = printerId;
        BranchId = branchId;
    }

    public uint Id { get; set; }
    
    public string InternalName { get; set; }
    
    public int InternalSerialNumber { get; set; }
    
    public bool IsDefault { get; set; }
    
    public uint PrinterId { get; set; }
    
    public uint BranchId { get; set; }
}