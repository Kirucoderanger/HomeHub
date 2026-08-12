using Microsoft.AspNetCore.Identity;

namespace HomeHub.Data;

public static class AdminSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var userManager =
            services.GetRequiredService<UserManager<ApplicationUser>>();

        var roleManager =
            services.GetRequiredService<RoleManager<IdentityRole>>();

        const string adminEmail = "test7@test.com";

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var user = await userManager.FindByEmailAsync(adminEmail);

        if (user is not null &&
            !await userManager.IsInRoleAsync(user, "Admin"))
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
