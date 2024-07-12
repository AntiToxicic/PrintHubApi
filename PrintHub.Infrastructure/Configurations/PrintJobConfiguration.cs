using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintHub.Core.Entities;

namespace PrintHub.Infrastructure.Configurations
{
    public class PrintJobConfiguration : IEntityTypeConfiguration<PrintJob>
    {
        public void Configure(EntityTypeBuilder<PrintJob> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Employee)
                .WithMany(c => c.PrintJobs)
                .HasForeignKey(c => c.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.PrinterInstallation)
                .WithMany(c => c.PrintJobs)
                .HasForeignKey(c => c.PrinterInstallationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}