using PrintHub.Core.Interfaces.Repositories;
using PrintHub.Core.Interfaces.Services;
using PrintHub.Core.Services;
using PrintHub.Infrastructure.Repositories;

namespace PrintHubAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBranchRepository, BranchRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IPrinterInstallationRepository, PrinterInstallationRepository>();
        services.AddScoped<IPrinterRepository, PrinterRepository>();
        services.AddScoped<IPrintJobRepository, PrintJobRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBranchService, BranchService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IPrinterInstallationService, PrinterInstallationService>();
        services.AddScoped<IPrinterService, PrinterService>();
        services.AddScoped<IPrintJobService, PrintJobService>();
        
        return services;
    }
}