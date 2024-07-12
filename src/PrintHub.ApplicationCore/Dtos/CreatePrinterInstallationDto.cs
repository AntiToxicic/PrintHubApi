namespace PrintHub.Core.Dtos;

public class CreatePrinterInstallationDto
{
    public CreatePrinterInstallationDto(string internalName, int internalSerialNumber, bool isDefault)
    {
        InternalName = internalName;
        InternalSerialNumber = internalSerialNumber;
        IsDefault = isDefault;
    }
    
    public string InternalName { get; set; }
    
    public int InternalSerialNumber { get; set; }
    
    public bool IsDefault { get; set; }
}