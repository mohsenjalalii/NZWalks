using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper) : ControllerBase
{
    private readonly NZWalksDbContext _db = dbContext;
    private readonly IRegionRepository _sqlDb = regionRepository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Region> regions = await _sqlDb.GetAllAsync();
        List<RegionDto> reginoDto = mapper.Map<List<RegionDto>>(regions);

        return Ok(reginoDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Region region = await _sqlDb.GetByIdAsync(id);

        if (region == null) return NotFound();

        RegionDto regionDto = mapper.Map<RegionDto>(region);

        return Ok(regionDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        Region newRegion = mapper.Map<Region>(addRegionRequestDto);
        await _sqlDb.CreateAsync(newRegion);
        RegionDto regionDto = mapper.Map<RegionDto>(newRegion);

        return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
    {
        Region convertedRegion = mapper.Map<Region>(updateRegionRequestDto);
        Region region = await _sqlDb.UpdateAsync(id, convertedRegion);

        if (region == null) return NotFound();

        RegionDto regionDto = mapper.Map<RegionDto>(region);

        return Ok(regionDto);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        Region region = await _sqlDb.DeleteAsync(id);

        if (region == null) return NotFound();

        return Ok();
    }
}