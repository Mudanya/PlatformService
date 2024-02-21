using PlatformService.Models;

namespace PlatformService.Data;

public interface IPlatformRepo 
{
    void CreatePlatform(Platform platform);
    Platform GetPlatform(int id);
    IEnumerable<Platform> GetAllPlatforms();
    bool SaveChanges();

}