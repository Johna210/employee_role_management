using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Infrastructure;
using EmployeeRoleManagement.Domain;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Infrastructure.OrganizationTree;

public class OrganizationTreeInfrastructure : IOrganizationTreeInfrastructure
{
    public List<Organization> BuildEmployeeOrganizationTree(List<Employee> employees)
    {
        // step 1: make organization dto from every employee dto
        var organizationLookup = employees.ToDictionary(
            e => e.Id, e => new Organization()
            {
                Id = e.Id,
                Name = e.Name,
                Role = e.Role,
                Description = e.Description,
                Children = new List<Organization>()
            });
        
        // step 2: List to hold the root Employees
        var rootEmployees = new List<Organization>();
        
        // step 3: Build the tree/ graph structure by linking roots to their children.
        foreach (var employee in employees)
        {
            if (employee.ParentId == null || employee.ParentId == Guid.Empty || !organizationLookup.ContainsKey(employee.ParentId))
            {
                // no parent, add directly to root
                rootEmployees.Add(organizationLookup[employee.Id]);
            }
            else
            {
                var parent = organizationLookup[employee.ParentId];
                parent.Children.Add(organizationLookup[employee.Id]);
            }
        }
        
        return rootEmployees;
    }
}