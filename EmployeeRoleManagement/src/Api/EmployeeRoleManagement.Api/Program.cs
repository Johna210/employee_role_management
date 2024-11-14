using EmployeeRoleManagement.Core.EmployeeRoleManagement.Application;
using EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Infrastructure;
using EmployeeRoleManagement.Infrastructure.EmployeeRoleManagement.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeRoleManagement.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Inject services
        builder.Services.ConfigureApplicationService();
        builder.Services.ConfigurePersistenceServices(builder.Configuration);
        builder.Services.ConfigureInfrastructureServices(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddCors(o =>
        {
            o.AddPolicy("CorsPolicy", 
                corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.UseCors("CorsPolicy");
        
        app.MapControllers();

        app.Run();
    }
}