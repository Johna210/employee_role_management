using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Commands;

public class UpdateEmployeeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateEmployeeDto UpdateEmployeeDto { get; set; }
    public ChangeParentDto ChangeParentDto { get; set; }
}