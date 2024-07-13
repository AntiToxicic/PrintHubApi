using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces;
using PrintHub.Core.Interfaces.Repositories;

namespace PrintHub.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MsSqlContext _context;

    public EmployeeRepository(MsSqlContext context)
    {
        _context = context;
    }

    public async Task<Employee?> Add(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public Task<Employee?> GetById(uint employeeId) =>
        _context.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);


    public async Task<Employee?> Update(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public Task Delete(Employee employee)
    {
        _context.Employees.Remove(employee);
        return _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Employee>> GetAll() =>
        await _context.Employees.ToListAsync();
}