namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Features.EmploeeRoleManagement.Handlers.Queries;

public class GetEmployeeChildrenRequestHandler : IRequestHandler<GetEmployeeChildrenRequest, List<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeChildrenRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }
    
    public async Task<List<EmployeeDto>> Handle(GetEmployeeChildrenRequest request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetBy(e => e.ParentId == request.Id);
        return _mapper.Map<List<EmployeeDto>>(employees);
    }
}