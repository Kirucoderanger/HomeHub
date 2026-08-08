
using Microsoft.EntityFrameworkCore;

namespace HomeHub.Data;

/// <summary>
/// Provides Entity Framework Core access to the HomeHub database.
/// The context will be extended with application entities as
/// additional features are implemented.
/// </summary>
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}