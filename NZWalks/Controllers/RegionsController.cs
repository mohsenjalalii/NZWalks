using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository) : ControllerBase
{
    private readonly NZWalksDbContext _db = dbContext;
    private readonly IRegionRepository _sqlDb = regionRepository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Region> regions = await _sqlDb.GetAllAsync();
        List<RegionDto> reginoDto = [];

        foreach (Region region in regions)
        {
            reginoDto.Add(new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            });
        }

        return Ok(reginoDto);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        Region region = await _sqlDb.GetByIdAsync(id);

        RegionDto regionDto = new RegionDto
        {
            Id = region.Id,
            Code = region.Code,
            Name = region.Name,
            RegionImageUrl = region.RegionImageUrl
        };

        if (region == null) return NotFound();

        return Ok(regionDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        Region newRegion = new Region
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl,
        };

        await _sqlDb.CreateAsync(newRegion);

        RegionDto regionDto = new RegionDto
        {
            Id = newRegion.Id,
            Code = newRegion.Code,
            Name = newRegion.Name,
            RegionImageUrl = newRegion.RegionImageUrl,
        };

        return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        Region convertedRegion = new()
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl
        };

        Region region = await _sqlDb.UpdateAsync(id, convertedRegion);

        if (region == null) return NotFound();

        RegionDto regionDto = new RegionDto
        {
            Id = region.Id,
            Code = region.Code,
            Name = region.Name,
            RegionImageUrl = region.RegionImageUrl
        };

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