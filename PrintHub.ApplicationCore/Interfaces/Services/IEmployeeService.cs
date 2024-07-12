using PrintHub.Core.Dtos;

namespace PrintHub.Core.Interfaces.Services;

public interface IEmployeeService
{
    public Task<EmployeeDto?> Add(CreateEmployeeDto employeeDto);
    
    public Task<EmployeeDto?> GetById(uint employeeId);
    
    public Task<EmployeeDto?> Update(EmployeeDto employee);
    
    public Task Delete(uint employeeId);
}