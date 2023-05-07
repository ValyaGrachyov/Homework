using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class PortfolioDbContext : IdentityDbContext
{
    public DbSet<Education> Educations { get; set; }
    public DbSet<RequestMessage> RequestMessages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Fact> Facts { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Experience> Experiences { get; set; }

    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}