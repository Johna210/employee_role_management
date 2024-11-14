using MediatR;

namespace EmployeeManagement.Core.EmployeeManagement.Application.Features.EmployeeRoleManagement.Requests.Commands;

public class DeleteEmployeeCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}