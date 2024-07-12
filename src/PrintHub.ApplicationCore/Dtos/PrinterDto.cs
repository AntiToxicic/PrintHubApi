using PrintHub.Core.Enums;

namespace PrintHub.Core.Dtos;

public class PrinterDto
{
    public PrinterDto(uint id, string name, ConnectionType connectionType, string? macAddress)
    {
        Id = id;
        Name = name;
        ConnectionType = connectionType;
        MacAddress = macAddress;
    }
    
    public uint Id { get; set; }

    public string Name { get; set; }
    
    public ConnectionType ConnectionType { get; set; }
    
    public string? MacAddress { get; set; }
}