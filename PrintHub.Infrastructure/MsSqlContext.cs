using Microsoft.EntityFrameworkCore;
using PrintHub.Core.Entities;
using PrintHub.Infrastructure.Configurations;

namespace PrintHub.Infrastructure;

public class MsSqlContext : DbContext
{
    public MsSqlContext(DbContextOptions<MsSqlContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Branch> Branches { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Printer> Printers { get; set; } = null!;
    public DbSet<PrinterInstallation> PrinterInstallations { get; set; } = null!;
    public DbSet<PrintJob> PrintJobs { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyMarker).Assembly);
    }
}