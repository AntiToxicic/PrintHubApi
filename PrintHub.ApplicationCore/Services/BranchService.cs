using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;

namespace PrintHub.Core.Services;

public class BranchService : IBranchService
{
    private readonly IBranchRepository _branchRepository;

    public BranchService(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<BranchDto?> Add(CreateBranchDto branchDto)
    {
        var branch = new Branch(branchDto.Name, branchDto.Location);
        branch = await _branchRepository.Add(branch);

        if (branch is null) return null;

        return new BranchDto(branch.Id, branch.Name, branch.Location);
    }

    public async Task<BranchDto?> GetById(uint branchId)
    {
        var branch = await _branchRepository.GetById(branchId);

        if (branch is null) return null;

        return new BranchDto(branch.Id, branch.Name, branch.Location);
    }

    public async Task<BranchDto?> Update(BranchDto branchDto)
    {
        var branch = new Branch(branchDto.Name, branchDto.Location) { Id = branchDto.Id };

        branch = await _branchRepository.Update(branch);

        if (branch is null) return null;

        return branchDto;
    }

    public async Task Delete(uint branchId)
    {
        var branch = await _branchRepository.GetById(branchId);

        if (branch is null) return;

        await _branchRepository.Delete(branch);
    }
}