using PrintHub.Core.Dtos;
using PrintHub.Core.Entities;
using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;

namespace PrintHub.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<EmployeeDto?> Add(CreateEmployeeDto employeeDto)
    {
        var employee = new Employee(employeeDto.Name);
        employee = await _employeeRepository.Add(employee);
        
        if (employee is null) return null;
        
        return new EmployeeDto(employee.Id, employee.Name, employee.BranchId);
    }

    public async Task<EmployeeDto?> GetById(uint employeeId)
    {
        var employee = await _employeeRepository.GetById(employeeId);

        if (employee is null) return null;

        return new EmployeeDto(employee.Id, employee.Name, employee.BranchId);
    }

    public async Task<EmployeeDto?> Update(EmployeeDto employeeDto)
    {
        var employee = await _employeeRepository.GetById(employeeDto.Id);

        if (employee is null) return null;

        employee.Id = employeeDto.Id;
        employee.Name = employeeDto.Name;

        await _employeeRepository.Update(employee);

        return new EmployeeDto(employee.Id, employee.Name, employee.BranchId);
    }

    public async Task Delete(uint employeeId)
    {
        var employee = await _employeeRepository.GetById(employeeId);
        
        if (employee is null) return;

        await _employeeRepository.Delete(employee);
    }

    public async Task<IReadOnlyCollection<EmployeeDto>> GetAll()
    {
        var employees = await _employeeRepository.GetAll();
        var employeesDto = new List<EmployeeDto>();

        foreach (var employee in employees)
        {
            employeesDto.Add(new EmployeeDto(employee.Id, employee.Name, employee.BranchId));
        }

        return employeesDto;
    }
}