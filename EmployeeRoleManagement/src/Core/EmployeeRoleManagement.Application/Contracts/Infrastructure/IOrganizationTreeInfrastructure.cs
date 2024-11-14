using EmployeeRoleManagement.Domain;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Infrastructure;

public interface IOrganizationTreeInfrastructure
{
    Task<List<Organization>> BuildEmployeeOrganizationTree(List<Employee> employees);
}