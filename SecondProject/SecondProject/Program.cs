using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Configure Data Protection to share authentication cookies between apps
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\DataProtectionKeys\")) // Shared location for keys
    .SetApplicationName("SharedSSOCookieApp"); // Shared application name between both projects


builder.Services.AddAuthentication(options =>
{
    // Ensure these match what the Primary App uses
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
})
    .AddCookie(IdentityConstants.ApplicationScheme, options =>
    {
        options.Cookie.Name = "MyAppCookie"; // Must be the same as in the primary app
        options.Cookie.HttpOnly = true;
        options.Cookie.Domain = "localhost"; // Ensure this domain is correct and matches the first app
        options.Cookie.SameSite = SameSiteMode.None; // Cross-domain cookies
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Must be HTTPS

        // Set the expiration and sliding expiration to refresh on each request
        options.ExpireTimeSpan = TimeSpan.FromMinutes(1); // Set the cookie expiration time
        options.SlidingExpiration = true; // Enable sliding expiration to extend the session on each request
                                          // Redirect to the login page in the First App
        options.LoginPath ="/AccessDenied";
        

    });


builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Ensure authentication middleware is used
app.UseAuthorization();

app.MapRazorPages();

app.Run();
