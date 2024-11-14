using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee.Validators;

public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeDtoValidator(IEmployeeRepository employeeRepository)
    {
        Include(new IEmployeeDtoValidator(employeeRepository));
        
        RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
    }
}