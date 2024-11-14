using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Common;
using FluentValidation;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee.Validators;

public class IDValidator : AbstractValidator<BaseDto>
{
    public static bool IsGuid(string? candidate)
    {
        if (candidate == null) return false;

        return Guid.TryParse(candidate, out _);
    }
    
    public IDValidator(IEmployeeRepository employeeRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Must((guid) => IsGuid(guid.ToString())).WithMessage("{PropertyName} must be a valid UUID");
        
        RuleFor(p => p.ParentId)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MustAsync(async (guid, token) =>
            {
                if (guid.HasValue && IsGuid(guid.Value.ToString())) 
                {
                    return await employeeRepository.Exists(guid.Value);   
                }  
                return false;
            })
            .WithMessage("{PropertyName} must be a valid GUID}")
            .When(p => p.ParentId.HasValue); 
    }
}