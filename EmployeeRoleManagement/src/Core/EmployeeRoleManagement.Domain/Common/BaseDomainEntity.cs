namespace EmployeeRoleManagement.Domain.Common;

public class BaseDomainEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public string Description { get; set; }   
}