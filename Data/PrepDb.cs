using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app, bool isProd)
    {
        using var appSvc = app.ApplicationServices.CreateScope();
        SeedData(appSvc.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
    }
    private static void SeedData(AppDbContext context, bool isProd)
    {
        if (isProd)
        {
            Console.WriteLine("--> Production Env");
            context.Database.Migrate();
        }
        
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding data");
            context.Platforms.AddRange(
                new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "SqlServer Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform() { Name = "Kurbenetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );
            context.SaveChanges();
        }
    }
}