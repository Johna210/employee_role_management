using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee.Validators;
using FluentValidation;

namespace EmployeeRoleManagement.Application.Dtos.Employee.Validators;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator(IEmployeeRepository employeeRepository)
    {
        Include(new IEmployeeDtoValidator(employeeRepository));
    }
}