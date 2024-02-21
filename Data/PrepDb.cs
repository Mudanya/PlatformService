using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var appSvc = app.ApplicationServices.CreateScope();
        SeedData(appSvc.ServiceProvider.GetRequiredService<AppDbContext>());
    }
    private static void SeedData(AppDbContext context)
    {
        if(!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding data");
            context.Platforms.AddRange(
                new Platform(){ Name = "Dot Net",Publisher="Microsoft",Cost="Free"},
                new Platform(){ Name = "SqlServer Express",Publisher="Microsoft",Cost="Free"},
                new Platform(){ Name = "Kurbenetes",Publisher="Cloud Native Computing Foundation",Cost="Free"}
            );
            context.SaveChanges();
        }
    }
}