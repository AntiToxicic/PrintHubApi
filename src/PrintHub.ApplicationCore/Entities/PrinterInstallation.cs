namespace PrintHub.Core.Entities;

public class PrinterInstallation : EntityBase
{
    public PrinterInstallation()
    {
    }

    public PrinterInstallation(string internalName, int internalSerialNumber, bool isDefault)
    {
        InternalName = internalName;
        InternalSerialNumber = internalSerialNumber;
        IsDefault = isDefault;
    }
    
    public string InternalName { get; set; }
    
    public int InternalSerialNumber { get; set; }
    
    public bool IsDefault { get; set; }
    
    public uint PrinterId { get; set; }
    public Printer? Printer { get; set; }
    
    public uint BranchId { get; set; }
    public Branch? Branch { get; set; }
    
    
    public List<PrintJob> PrintJobs { get; set; }
}