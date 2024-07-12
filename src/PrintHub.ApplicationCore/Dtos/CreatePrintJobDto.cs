namespace PrintHub.Core.Dtos;

public class CreatePrintJobDto
{
    public CreatePrintJobDto(string name, uint pageCount, bool isSuccess)
    {
        Name = name;
        PageCount = pageCount;
        IsSuccess = isSuccess;
    }

    public string Name { get; set; }
    
    public uint PageCount { get; set; }
    
    public bool IsSuccess { get; set; }
}