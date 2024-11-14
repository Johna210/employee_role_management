using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;

public class GetEmployeeDetailRequest : IRequest<EmployeeDto>
{
    public Guid Id { get; set; }
}