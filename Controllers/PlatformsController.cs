using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController: ControllerBase
{
    private readonly IPlatformRepo _platform;
    private readonly IMapper _mapper;

    public PlatformsController(IPlatformRepo platform, IMapper mapper)
    {
        _platform = platform;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPlatforms()
    {
        var platforms = _platform.GetAllPlatforms();
        var platformsDto = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);
        if(platforms is null) return NotFound();
        return Ok(platformsDto);
    }
    [HttpGet("{id}",Name ="GetPlatformById")]
    public IActionResult GetPlatform(int id)
    {
        var platform = _platform.GetPlatform(id);
        if(platform is null) return NotFound();
        var platformDto = _mapper.Map<PlatformReadDto>(platform);
        return Ok(platform);
    }

    [HttpPost]
    public IActionResult AddPlatform([FromBody] PlatformCreateDto createDto)
    {
        if(createDto is null) return BadRequest("");
        var platform = _mapper.Map<Platform>(createDto);
        _platform.CreatePlatform(platform);
        _platform.SaveChanges();
        var platformDto = _mapper.Map<PlatformReadDto>(platform);
        return CreatedAtRoute("GetPlatformById",new {Id = platformDto.Id},platformDto);
    }
}