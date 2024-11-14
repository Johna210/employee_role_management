using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;

public class GetEmployeeRoleDetailRequest : IRequest<List<EmployeeDto>> 
{
    public string Role { get; set; }   
}