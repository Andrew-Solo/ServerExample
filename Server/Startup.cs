using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Data;

namespace Server;

public static class Setup
{
    public static WebApplicationOptions DefaultWebApplicationOptions => new()
    {
        ApplicationName = "RnDJunior",
    };
    
    public static List<Action<WebApplicationBuilder>> DefaultBuild => new()
    {
        builder =>
        {
            //Database
            if (builder.Environment.IsDevelopment())
            {
                string? connectionString = builder.Configuration.GetConnectionString("DevelopmentConnection");
                builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            }
            else
            {
                string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            }
        },
        builder => builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DataContext>(),
        builder => builder.Services.AddControllers(),
    };

    public static List<Action<WebApplication>> DefaultPipeline => new()
    {
        application =>
        {
            if (application.Environment.IsDevelopment()) application.UseHttpsRedirection();
        },
        application =>
        {
            if (!application.Environment.IsDevelopment()) application.UseHsts();
        },
            
        application => application.UseHttpsRedirection(),
        application => application.UseStaticFiles(),
        application => application.UseRouting(),
            
        application => application.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action=Index}/{id?}"),
            
        application => application.MapGet("/", () => "Hello World!"),
    };
}
