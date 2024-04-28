using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncData.Http;

namespace PlatformService.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureInMemoryContext(this IServiceCollection services) 
        => services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
    public static void ConfigurePlatformRepo(this IServiceCollection services)
        => services.AddScoped<IPlatformRepo, PlatformRepo>();
    public static void ConfigureCommandClient(this IServiceCollection service)
        => service.AddScoped<ICommandData, CommandData>();
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        => services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(config.GetConnectionString("PlatformConn")));
}