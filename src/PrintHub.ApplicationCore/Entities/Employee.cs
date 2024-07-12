namespace PrintHub.Core.Entities;

public class Employee : EntityBase
{
    public Employee()
    {
    }

    public Employee(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    
    public uint BranchId { get; set; }
    public Branch? Branch { get; set; }
    
    public List<PrintJob> PrintJobs { get; set; }
}