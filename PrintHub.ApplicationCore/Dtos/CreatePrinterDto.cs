using PrintHub.Core.Enums;

namespace PrintHub.Core.Dtos;

public class CreatePrinterDto
{
    public CreatePrinterDto(string name, ConnectionType connectionType, string macAddress)
    {
        Name = name;
        ConnectionType = connectionType;
        MacAddress = macAddress;
    }

    public string Name { get; set; }
    
    public ConnectionType ConnectionType { get; set; }
    
    public string? MacAddress { get; set; }
}