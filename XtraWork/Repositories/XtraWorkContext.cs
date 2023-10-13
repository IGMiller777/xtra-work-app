using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XtraWork.Entities;

namespace XtraWork.Repositories;

public class XtraWorkContext : DbContext
{
    public XtraWorkContext(DbContextOptions<XtraWorkContext> options) : base(options) {}
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        EntityTypeBuilder<Title> title = modelBuilder.Entity<Title>();
        // title.HasKey(a => a.Id);
        // title.Property(a => a.Id).ValueGeneratedOnAdd();
        title.Property(a => a.Description).HasMaxLength(255);
    }
}