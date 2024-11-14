using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee.Validators;

public class IEmployeeDtoValidator : AbstractValidator<IEmployeeDto>
{
    public IEmployeeDtoValidator(IEmployeeRepository employeeRepository)
    {
        RuleFor(p => p.Name).
            NotEmpty().WithMessage("{PropertyName} is required");
        
        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.Role)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (role, token) =>
            {
                var hasRoot = await employeeRepository.IsEmployeeRoot(role);
                return hasRoot;
            }).WithMessage("Cannot be this role");

    }
}