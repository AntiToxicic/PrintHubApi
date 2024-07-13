using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintHub.Core.Entities;

namespace PrintHub.Infrastructure.Configurations;

public class PrinterInstallationConfiguration : IEntityTypeConfiguration<PrinterInstallation>
{
    public void Configure(EntityTypeBuilder<PrinterInstallation> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.InternalSerialNumber)
            .IsRequired();

        builder.HasOne(c => c.Printer)
            .WithMany(c => c.PrinterInstallations)
            .HasForeignKey(c => c.PrinterId);

        builder.HasOne(c => c.Branch)
            .WithMany(c => c.PrinterInstallations)
            .HasForeignKey(c => c.BranchId);

        builder.HasIndex(c => new { c.PrinterId, c.BranchId }).IsUnique();
    }
}