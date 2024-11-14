using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Persistence;

public class EmployeeRoleManagementDbContextFactory : IDesignTimeDbContextFactory<EmployeeRoleManagementDbContext>
{
    public EmployeeRoleManagementDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<EmployeeRoleManagementDbContext>();
        var connectionString = configuration.GetConnectionString("EmployeeRoleManagementConnectionString");
        
        optionsBuilder.UseNpgsql(connectionString);
        
        return new EmployeeRoleManagementDbContext(optionsBuilder.Options);
    }
}