using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRoleManagement.Core.EmployeeRoleManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}