using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext context;

    public PlatformRepo(AppDbContext context)
    {
        this.context = context;
    }
    public void CreatePlatform(Platform platform)
        => context.Add(platform);

    public IEnumerable<Platform> GetAllPlatforms()
        => context.Platforms;

    public Platform GetPlatform(int id) 
        => context.Platforms.FirstOrDefault(p => p.Id == id);
    public bool SaveChanges() => context.SaveChanges() >= 0;
}