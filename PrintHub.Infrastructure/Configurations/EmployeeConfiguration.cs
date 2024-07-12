using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintHub.Core.Entities;

namespace PrintHub.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.HasOne(c => c.Branch)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.BranchId);
    }
}