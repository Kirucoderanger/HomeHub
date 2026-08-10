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
}
