using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Exceptions;
using EmployeeRoleManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Persistence.Repositories;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly EmployeeRoleManagementDbContext _context;

    public EmployeeRepository(EmployeeRoleManagementDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<Employee?> GetEmployeeWithDetails(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);
        return employee;
    }

    public async Task<List<Employee>> GetEmployeesWithDetails()
    {
        var employees = await _context.Employees.ToListAsync();
        return employees;
    }

    public async Task<List<Employee>> GetEmployeesByRoleWithDetails(string role)
    {
        var employees = await _context.Employees
            .Where(e => e.Role == role)
            .ToListAsync();
        return employees;
    }

    public async Task ChangeEmployeeParent(Guid id, Guid newParentId)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            throw new NotFoundException(nameof(employee), id);
        }

        if (newParentId == id)
        {
            throw new BadRequestException("Parent cannot be itself");
        }

        // if (await IsDesendant(id, newParentId))
        // {
        //     await ChangeEmployeeParentWithDesendant(id, newParentId);
        // } else
        // {
        employee.ParentId = newParentId;
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();    
        // }
    }

    public async Task<bool> IsEmployeeRoot(string role)
    {
        var employee = await _context.Employees
            .Where(e => e.Role == role && e.ParentId == null)
            .FirstOrDefaultAsync();

        return employee != null;
    }

    public Task<bool> IsDesendant(Guid id, Guid newParentId)
    {
        throw new NotImplementedException();
    }

    public Task ChangeEmployeeParentWithDesendant(Guid id, Guid newParentId)
    {
        throw new NotImplementedException();
    }
}