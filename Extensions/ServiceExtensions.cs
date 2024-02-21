using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureInMemoryContext(this IServiceCollection services) 
        => services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
    public static void ConfigurePlatformRepo(this IServiceCollection services)
        => services.AddScoped<IPlatformRepo, PlatformRepo>();
}