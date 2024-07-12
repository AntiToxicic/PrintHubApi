namespace PrintHub.Core.Entities;

public class PrintJob : EntityBase
{
    public PrintJob()
    {
    }

    public PrintJob(string name, uint pageCount, bool isSuccess)
    {
        Name = name;
        PageCount = pageCount;
        IsSuccess = isSuccess;
    }

    public string Name { get; set; }
    
    public uint PageCount { get; set; }
    
    public bool IsSuccess { get; set; }
    
    public uint EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    
    public uint PrinterInstallationId { get; set; }
    public PrinterInstallation? PrinterInstallation { get; set; }
}