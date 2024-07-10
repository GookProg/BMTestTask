using BMTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMTestTask.DataAccess.Postgre.Configurations;

public class BrandTaskConfiguration : IEntityTypeConfiguration<BrandTask>
{
    public void Configure(EntityTypeBuilder<BrandTask> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Timestamp);

        builder.Property(p => p.Status);
    }
}