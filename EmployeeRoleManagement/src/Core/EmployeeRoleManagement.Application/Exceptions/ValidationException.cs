using FluentValidation.Results;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<string> Errors { get; } = new List<string>();

    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add(error.ErrorMessage);
        }
    }
}