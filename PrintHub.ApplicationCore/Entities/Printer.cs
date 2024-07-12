using PrintHub.Core.Enums;

namespace PrintHub.Core.Entities;

public class Printer : EntityBase
{
    public Printer()
    {
    }

    public Printer(string name, ConnectionType connectionType, string? macAddress)
    {
        Name = name;
        ConnectionType = connectionType;
        MacAddress = macAddress;
    }

    public string Name { get; set; }
    
    public ConnectionType ConnectionType { get; set; }
    
    public string? MacAddress { get; set; }
    
    public List<PrinterInstallation> PrinterInstallations { get; set; }
}