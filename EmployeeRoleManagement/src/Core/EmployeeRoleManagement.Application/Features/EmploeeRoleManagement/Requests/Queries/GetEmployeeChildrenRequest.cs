using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;

public class GetEmployeeChildrenRequest : IRequest<List<EmployeeDto>>
{
    public Guid Id { get; set; }
}