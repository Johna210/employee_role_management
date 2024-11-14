using AutoMapper;
using EmployeeRoleManagement.Application.Dtos.Employee.Validators;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Commands;
using EmployeeRoleManagement.Domain;
using FluentValidation;
using MediatR;

namespace EmployeeManagement.Core.EmployeeManagement.Application.Features.EmployeeRoleManagement.Handlers.Commands;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateEmployeeDtoValidator(_employeeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateEmployeeDto, cancellationToken);
        
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult.Errors);
        
        var employee = _mapper.Map<Employee>(request.CreateEmployeeDto);
        employee = await _employeeRepository.Add(employee);
        
        return employee.Id;
    }
}