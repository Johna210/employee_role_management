using EmployeeRoleManagement.Domain.Common;

namespace EmployeeRoleManagement.Domain;

public class Organization : BaseDomainEntity
{
    public List<Organization> Children { get; set; } = new List<Organization>();
}