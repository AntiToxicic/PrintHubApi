using PrintHub.Core.Entities;

namespace PrintHub.Core.Interfaces.Repositories;

public interface IBranchRepository
{
    public Task<Branch?> Add(Branch branchDto);
    
    public Task<Branch?> GetById(uint branchId);
    
    public Task<Branch?> Update(Branch branch);
    
    public Task Delete(Branch branch);
}