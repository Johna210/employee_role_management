using AutoMapper;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Handlers.Queries;

public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeListRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<List<EmployeeDto>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetEmployeesWithDetails();
        return _mapper.Map<List<EmployeeDto>>(employees);
    }
}