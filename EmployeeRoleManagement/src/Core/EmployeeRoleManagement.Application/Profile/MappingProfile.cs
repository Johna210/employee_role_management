using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Dtos.Employee;
using EmployeeRoleManagement.Domain;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Profile;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
    }
}