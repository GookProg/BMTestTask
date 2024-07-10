using BMTestTask.DataAccess.Postgre.Configurations;
using BMTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BMTestTask.DataAccess.Postgre;

public class BMTestTaskDbContext : DbContext
{
    public BMTestTaskDbContext(DbContextOptions<BMTestTaskDbContext> options)
        : base(options)
    {
    }

    public DbSet<BrandTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandTaskConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}