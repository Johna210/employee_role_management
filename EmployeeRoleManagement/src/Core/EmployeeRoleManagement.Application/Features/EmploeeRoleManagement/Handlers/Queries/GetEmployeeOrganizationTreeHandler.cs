using AutoMapper;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Infrastructure;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Persistence;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Requests.Queries;
using MediatR;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Handlers.Queries;

public class GetEmployeeOrganizationTreeHandler : IRequestHandler<GetEmployeeOrganizationTree, List<OrganizationDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;
    private readonly IOrganizationTreeInfrastructure _organizationTreeInfrastructure;

    public GetEmployeeOrganizationTreeHandler(IEmployeeRepository employeeRepository, IMapper mapper, IOrganizationTreeInfrastructure organizationTreeInfrastructure)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _organizationTreeInfrastructure = organizationTreeInfrastructure;
    }
    
    public async Task<List<OrganizationDto>> Handle(GetEmployeeOrganizationTree request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetEmployeesWithDetails();
        
        var employeeTree = _organizationTreeInfrastructure.BuildEmployeeOrganizationTree(employees);
        
        return _mapper.Map<List<OrganizationDto>>(employeeTree);
    }
}