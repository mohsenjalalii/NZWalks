using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WalkController(IWalkRepository walkRepository, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly IWalkRepository walkRepository = walkRepository;

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        IEnumerable<Walk> walks = await walkRepository.GetAllAsync();
        IEnumerable<WalkDto> walkdDto = _mapper.Map<IEnumerable<WalkDto>>(walks);

        return Ok(walkdDto);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetWalk([FromRoute] Guid id)
    {
        Walk walk = await walkRepository.GetById(id);
        WalkDto walkDto = _mapper.Map<WalkDto>(walk);

        return Ok(walkDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
    {
        Walk newWalk = _mapper.Map<Walk>(addWalkRequestDto);
        await walkRepository.CreateAsync(newWalk);
        WalkDto walkDto = _mapper.Map<WalkDto>(newWalk);

        return Ok(walkDto);
    }
}