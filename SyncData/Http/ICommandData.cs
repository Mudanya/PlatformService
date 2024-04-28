using PlatformService.Dtos;

namespace PlatformService.SyncData.Http;

public interface ICommandData
{
    Task SendPlatformToCommand(PlatformReadDto platform);
}