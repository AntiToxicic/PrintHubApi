namespace PrintHub.Core.Dtos;

public class BranchDto
{
    public BranchDto(uint id, string name, string location)
    {
        Id = id;
        Name = name;
        Location = location;
    }

    public uint Id { get; set; }

    public string Name { get; set; }

    public string Location { get; set; }
}