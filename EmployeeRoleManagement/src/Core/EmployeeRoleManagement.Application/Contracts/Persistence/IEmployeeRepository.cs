using EmployeeRoleManagement.Domain;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee> GetEmployeeWithDetails(Guid id);
    Task<List<Employee>> GetEmployeesWithDetails();
    Task<List<Employee>> GetEmployeesByRoleWithDetails(string role);
    Task ChangeEmployeeParent(Guid id, Guid newParentId);
    Task<bool> IsEmployeeRoot(string role);
}