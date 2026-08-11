using HomeHub.Components;
using HomeHub.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;

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
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // The default HSTS value is 30 days. You may want to change this
    // for production scenarios.
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

app.MapRazorComponents<HomeHub.Components.App>()
    .AddInteractiveServerRenderMode();

//Endpoint to handle secure cookie invalidation and logout
app.MapPost("/account/logout", async (
    SignInManager<ApplicationUser> signInManager,
    NavigationManager navigationManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Redirect("/account/login");
});


// Database health check endpoint.
// This endpoint is intended for development and diagnostics.
app.MapGet("/health/database", async (ApplicationDbContext db) =>
{
    try
    {
        var canConnect = await db.Database.CanConnectAsync();

        return canConnect
            ? Results.Ok(new { status = "connected" })
            : Results.Problem("Database connection failed.");
    }
    catch (Exception)
    {
        return Results.Problem(
            detail: "Unable to connect to the database.",
            statusCode: 500);
    }
});

app.Run();

