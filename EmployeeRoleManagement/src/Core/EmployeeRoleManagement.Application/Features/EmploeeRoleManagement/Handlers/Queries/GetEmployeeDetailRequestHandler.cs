using AutoMapper;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Handlers.Queries;

public class GetEmployeeDetailRequestHandler : IRequestHandler<GetEmployeeDetailRequest, EmployeeDto>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeDetailRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<EmployeeDto> Handle(GetEmployeeDetailRequest request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeWithDetails(request.Id);
        return _mapper.Map<EmployeeDto>(employee);
    }
}