using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Common;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;

public class EmployeeDto : BaseDto, IEmployeeDto
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }
}