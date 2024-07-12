using PrintHub.Core.Entities;

namespace PrintHub.Core.Interfaces.Repositories;

public interface IEmployeeRepository
{
    public Task<Employee?> Add(Employee employee);
    
    public Task<Employee?> GetById(uint employeeId);
    
    public Task<Employee?> Update(Employee employee);
    
    public Task Delete(Employee employee);
}