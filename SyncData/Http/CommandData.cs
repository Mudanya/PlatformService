using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncData.Http;

public class CommandData : ICommandData
{
    private readonly IHttpClientFactory httpClient;
    private readonly IConfiguration config;

    public CommandData(IHttpClientFactory httpClient, IConfiguration config)
    {
        this.httpClient = httpClient;
        this.config = config;
    }
    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var platBody = new StringContent(
            JsonSerializer.Serialize(platform),
            Encoding.UTF8,
            "application/json"
        );
        var client = httpClient.CreateClient();
        var res = await client.PostAsync(config["CommandSvcUrl"],platBody);
        if(res.IsSuccessStatusCode) Console.WriteLine("--> Sync Post to Cmd Svc was Successful");
        else Console.WriteLine("--> Sync Post to Cmd Svc was Successful");
    }
}