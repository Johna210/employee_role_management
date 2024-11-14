using System.Reflection;
using EmployeeRoleManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Persistence;

public class EmployeeRoleManagementDbContext : DbContext
{
    public EmployeeRoleManagementDbContext(DbContextOptions<EmployeeRoleManagementDbContext> options)
    : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeRoleManagementDbContext).Assembly);
    }
    
    public DbSet<Employee> Employees { get; set; }
}