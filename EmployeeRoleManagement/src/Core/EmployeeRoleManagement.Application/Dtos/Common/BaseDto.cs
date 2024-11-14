namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Common;

public class BaseDto
{
    public Guid Id { get; set; }
    public Guid? ParentId { get; set; }
}