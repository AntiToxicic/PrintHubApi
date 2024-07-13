using PrintHub.Core.Dtos;

namespace PrintHub.Core.Interfaces.Services;

public interface IBranchService
{
    public Task<BranchDto?> Add(CreateBranchDto branchDto);
    
    public Task<BranchDto?> GetById(uint branchId);
    
    public Task<BranchDto?> Update(BranchDto branchDto);
    
    public Task Delete(uint branchId);

    public Task<IReadOnlyCollection<BranchDto>> GetAll();
}