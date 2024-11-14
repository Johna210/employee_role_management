using AutoMapper;
using EmployeeManagement.Core.EmployeeManagement.Application.Features.EmployeeRoleManagement.Requests.Commands;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Exceptions;
using EmployeeRoleManagement.Domain;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Handlers.Commands;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.Get(request.Id);

        if (employee == null)
            throw new NotFoundException(nameof(Employee), request.Id);
        
        await _employeeRepository.Delete(employee);
        
        return Unit.Value;
    }
}