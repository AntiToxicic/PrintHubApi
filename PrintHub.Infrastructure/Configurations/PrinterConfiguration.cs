using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintHub.Core.Entities;

namespace PrintHub.Infrastructure.Configurations;

public class PrinterConfiguration : IEntityTypeConfiguration<Printer>
{
    public void Configure(EntityTypeBuilder<Printer> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.ConnectionType)
            .HasConversion<string>();
        
        builder.Property(c => c.MacAddress)
            .HasMaxLength(17);
    }
}