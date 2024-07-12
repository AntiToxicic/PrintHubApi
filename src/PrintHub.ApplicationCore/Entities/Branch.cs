namespace PrintHub.Core.Entities;

public class Branch : EntityBase
{
    public Branch()
    {
    }
    
    public Branch(string name, string location)
    {
        Name = name;
        Location = location;
    }

    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public List<Employee> Employees { get; set; }
    public List<PrinterInstallation> PrinterInstallations { get; set; }
}