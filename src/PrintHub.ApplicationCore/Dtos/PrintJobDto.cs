namespace PrintHub.Core.Dtos;

public class PrintJobDto
{
    public PrintJobDto(uint id, string name, uint pageCount, bool isSuccess, uint employeeId, uint printerInstallationId)
    {
        Id = id;
        Name = name;
        PageCount = pageCount;
        IsSuccess = isSuccess;
        EmployeeId = employeeId;
        PrinterInstallationId = printerInstallationId;
    }

    public uint Id { get; set; }
    
    public string Name { get; set; }
    
    public uint PageCount { get; set; }
    
    public bool IsSuccess { get; set; }
    
    public uint EmployeeId { get; set; }
    
    public uint PrinterInstallationId { get; set; }
}