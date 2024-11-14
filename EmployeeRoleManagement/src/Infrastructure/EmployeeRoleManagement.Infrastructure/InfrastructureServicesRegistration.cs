using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application.Contracts.Infrastructure;
using EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Infrastructure.OrganizationTree;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IOrganizationTreeInfrastructure, OrganizationTreeInfrastructure>();
        return services;
    }
}