using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.Models.Domain;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController(NZWalksDbContext dbContext) : ControllerBase
{
    private readonly NZWalksDbContext _db = dbContext;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Region> regions = await _db.Region.ToListAsync();
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
        Region region = await _db.Region.FirstOrDefaultAsync(r => r.Id == id);
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

        await _db.Region.AddAsync(newRegion);
        await _db.SaveChangesAsync();

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
        Region region = await _db.Region.FirstOrDefaultAsync(r => r.Id == id);

        if (region == null) return NotFound();

        region.Code = addRegionRequestDto.Code;
        region.Name = addRegionRequestDto.Name;
        region.RegionImageUrl = addRegionRequestDto.RegionImageUrl;

        await _db.SaveChangesAsync();

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
        Region region = await _db.Region.FirstOrDefaultAsync(r => r.Id == id);

        if (region == null) return NotFound();

        _db.Region.Remove(region);
        await _db.SaveChangesAsync();

        return Ok();
    }
}