using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Commands;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public CreateEmployeeDto CreateEmployeeDto { get; set; }
}