using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces;
using PrintHub.Core.Interfaces.Repositories;

namespace PrintHub.Infrastructure.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly MsSqlContext _context;

    public BranchRepository(MsSqlContext context)
    {
        _context = context;
    }

    public async Task<Branch?> Add(Branch branch)
    {
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();

        return branch;
    }

    public Task<Branch?> GetById(uint branchId) =>
        _context.Branches.FirstOrDefaultAsync(c => c.Id == branchId);

    public async Task<Branch?> Update(Branch branch)
    {
        if (await _context.Branches.FindAsync(branch.Id) is null)
            return null;
        
        _context.ChangeTracker.Clear(); 
        
        _context.Branches.Update(branch);
        await _context.SaveChangesAsync();

        return branch;
    }

    public Task Delete(Branch branch)
    {
        _context.Branches.Remove(branch);
        return _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Branch>> GetAll() =>
        await _context.Branches.ToListAsync();

}