using Microsoft.AspNetCore.Identity;

namespace HomeHub.Data;

/// <summary>
/// Represents a HomeHub user and extends ASP.NET Core Identity
/// with application-specific user information.
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the user's display name.
    /// </summary>
    public string? DisplayName { get; set; }
}
