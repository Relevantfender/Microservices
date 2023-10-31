using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.Repositories;

namespace PlatformService.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
  private readonly IPlatformRepo _repository;
  private readonly IMapper _mapper;

  public PlatformsController(IPlatformRepo repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpGet]
  public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
  {
    Console.WriteLine("--> Getting Platforms");
    var platformItem = _repository.GetAllPlatforms();
    return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItem));
  }

  [HttpGet("{id}", Name = "GetPlatformByID")]
  public ActionResult<PlatformReadDTO> GetPlatformById(int id)
  {
    Console.WriteLine("--> Getting Platform by id");
    var platformItem = _repository.GetPlatformByID(id);
    if (platformItem != null)
    {
      return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
    }
    else
      return NotFound();
  }

  //getting data from body
  [HttpPost]
  public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
  {
    var platformModel = _mapper.Map<Platform>(platformCreateDTO);
    _repository.CreatePlatform(platformModel);
    _repository.SaveChanges();

    var PlatformReadDTO = _mapper.Map<PlatformReadDTO>(platformModel);
    return CreatedAtRoute(nameof(GetPlatformById), new { Id = PlatformReadDTO.Id }, PlatformReadDTO);
  }

}
