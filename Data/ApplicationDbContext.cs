using HomeHub.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Data;

/// <summary>
/// Provides Entity Framework Core access to the HomeHub database
/// and manages ASP.NET Core Identity data.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    /// <summary>
    /// Initializes a new instance of the database context.
    /// </summary>
    /// <param name="options">The database context configuration.</param>
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Property> Properties => Set<Property>();

    public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();

    public DbSet<PropertyFavorite> PropertyFavorites => Set<PropertyFavorite>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Property>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PropertyImage>()
            .HasOne(i => i.Property)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<PropertyFavorite>()
            .HasKey(f => new { f.PropertyId, f.UserId });

        builder.Entity<PropertyFavorite>()
            .HasOne(f => f.Property)
            .WithMany(p => p.Favorites)
            .HasForeignKey(f => f.PropertyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<PropertyFavorite>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

