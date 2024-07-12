namespace PrintHub.Core.Dtos;

public class CreateBranchDto
{
    public CreateBranchDto(string name, string location)
    {
        Name = name;
        Location = location;
    }

    public string Name { get; set; }

    public string Location { get; set; }
}