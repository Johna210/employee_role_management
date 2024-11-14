using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;

public class CreateEmployeeDto : IEmployeeDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
    public Guid? ParentId { get; set; }
}