using EmployeeRoleManagement.Domain.Common;

namespace EmployeeRoleManagement.Domain;

public class Employee : BaseDomainEntity
{
    public Guid ParentId { get; set; }
}