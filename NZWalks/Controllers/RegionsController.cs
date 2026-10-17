using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.CustomActionFilters;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(
    NZWalksDbContext dbContext,
    IRegionRepository regionRepository,
    IMapper mapper
) : ControllerBase
{
    private readonly NZWalksDbContext _db = dbContext;
    private readonly IRegionRepository regionRepository = regionRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Region> regions = await regionRepository.GetAllAsync();
        List<RegionDto> reginoDto = _mapper.Map<List<RegionDto>>(regions);

        return Ok(reginoDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Region region = await regionRepository.GetByIdAsync(id);

        if (region == null)
            return NotFound();

        RegionDto regionDto = _mapper.Map<RegionDto>(region);

        return Ok(regionDto);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        Region newRegion = _mapper.Map<Region>(addRegionRequestDto);
        await regionRepository.CreateAsync(newRegion);
        RegionDto regionDto = _mapper.Map<RegionDto>(newRegion);

        return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [ValidateModel]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateRegionRequestDto updateRegionRequestDto
    )
    {
        Region convertedRegion = _mapper.Map<Region>(updateRegionRequestDto);
        Region region = await regionRepository.UpdateAsync(id, convertedRegion);

        if (region == null)
            return NotFound();

        RegionDto regionDto = _mapper.Map<RegionDto>(region);

        return Ok(regionDto);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        Region region = await regionRepository.DeleteAsync(id);

        if (region == null)
            return NotFound();

        return Ok();
    }
}
