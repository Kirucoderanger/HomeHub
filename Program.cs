using HomeHub.Components;
using HomeHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register Entity Framework Core and configure the application
// to use the Azure SQL database defined in the connection string.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

// Register ASP.NET Core Identity and configure the application
// to use ApplicationUser for authentication and authorization.
builder.Services
.AddDefaultIdentity<ApplicationUser>(options =>
{
options.SignIn.RequireConfirmedAccount = false;


    // Password requirements
    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
})

.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();


// Add services to the container.
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider
        .GetRequiredService<RoleManager<IdentityRole>>();

    var userManager = scope.ServiceProvider
        .GetRequiredService<UserManager<ApplicationUser>>();

    string[] roles =
    {
        "Admin",
        "PropertyOwner",
        "User"
    };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(
                new IdentityRole(role));
        }
    }

    // Give existing users the default User role
    var users = userManager.Users.ToList();

    foreach (var user in users)
    {
        var userRoles = await userManager.GetRolesAsync(user);

        if (userRoles.Count == 0)
        {
            await userManager.AddToRoleAsync(user, "User");
        }
    }

    // Seed the admin user
    await AdminSeeder.SeedAsync(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler(
"/Error",
createScopeForErrors: true);


app.UseHsts();


}

app.UseStatusCodePagesWithReExecute(
"/not-found",
createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

// Authentication and authorization middleware.
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();

// Secure logout endpoint.
// The browser submits a POST request here,
// Identity clears the authentication cookie,
// and the user is redirected to the login page.
app.MapPost(
"/account/logout",
async (SignInManager<ApplicationUser> signInManager) =>
{
await signInManager.SignOutAsync();


    return Results.Redirect(
        "/account/login?loggedout=true");
});


// Razor Components
app.MapRazorComponents<HomeHub.Components.App>()
.AddInteractiveServerRenderMode();

// Database health check endpoint.
// Intended for development and diagnostics.
app.MapGet(
"/health/database",
async (ApplicationDbContext db) =>
{
try
{
var canConnect =
await db.Database.CanConnectAsync();


        return canConnect
            ? Results.Ok(new { status = "connected" })
            : Results.Problem(
                "Database connection failed.");
    }
    catch (Exception)
    {
        return Results.Problem(
            detail:
                "Unable to connect to the database.",
            statusCode: 500);
    }
});

app.MapGet("/property-images/{id:int}", async (
    int id,
    ApplicationDbContext db) =>
{
    var image = await db.PropertyImages
        .AsNoTracking()
        .FirstOrDefaultAsync(i => i.Id == id);

    if (image is null)
    {
        return Results.NotFound();
    }

    return Results.File(
        image.Data,
        image.ContentType,
        image.FileName);
});


app.Run();
