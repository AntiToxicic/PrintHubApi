namespace PrintHub.Core.Dtos;

public class CreateEmployeeDto
{
    public CreateEmployeeDto(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}