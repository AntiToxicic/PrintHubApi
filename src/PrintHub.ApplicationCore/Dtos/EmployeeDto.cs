namespace PrintHub.Core.Dtos;

public class EmployeeDto
{
    public EmployeeDto(uint id, string name, uint branchId)
    {
        Id = id;
        Name = name;
        BranchId = branchId;
    }

    public uint Id { get; set; }
    
    public string Name { get; set; }
    
    public uint BranchId { get; set; }
}