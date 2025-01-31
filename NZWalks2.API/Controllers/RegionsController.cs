using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Data;
using NZWalks2.API.DTOS;
using NZWalks2.API.Models.Domain;
using NZWalks2.API.Repositories;

namespace NZWalks2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionRepositry _regionRepository;

        public RegionsController(NZWalksDbContext context ,IRegionRepositry RegionRepository )
        {
            _context = context;
            _regionRepository = RegionRepository;
        }

        #region Getting All Regions

        [HttpGet("GetAll")]
        public async Task <IActionResult> GetAllRegions()
        {

            //by implementing aysnchronous programming the code execution will not be blocked
            var Regions = await _regionRepository.GetAllRegionsAsync();

            var RegionsDto = new List<RegionDTO>();
            foreach (var region in Regions)
            {
                RegionsDto.Add(
                    new RegionDTO()
                    {
                        Id = region.Id,
                        Code = region.Code,
                        Name = region.Name,
                        RegionImgUrl = region.RegionImgUrl
                    });
            }

            return Ok(RegionsDto);

        }
        #endregion  
            
        #region Get A Region By Id

        [HttpGet("GetRegion/{id:Guid}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var RegionDomain = await _regionRepository.GetByidAsync(id);

            if (RegionDomain != null)
            {
                var RegionDTO = new RegionDTO()
                {
                    Id = RegionDomain.Id,
                    Code = RegionDomain.Code,
                    Name = RegionDomain.Name,
                    RegionImgUrl = RegionDomain.RegionImgUrl
                };

                return Ok(RegionDTO);
            }


            else
            {
                return NotFound(new { success = false, message = "No Region Found" });
            }
        }

        #endregion

        #region Create Region
        [HttpPost("Add-Region")]
        public async Task<IActionResult> CreateRegion ([FromBody]AddRegionDto dto)
        {
            var RegionDomainModel = new Region()
            {
                Code = dto.Code,
                Name = dto.Name,
                RegionImgUrl = dto.RegionImgUrl
            };

            RegionDomainModel = await _regionRepository.CreateRegionAsync(RegionDomainModel);
            await _context.SaveChangesAsync();  

           //await _context.Set<Region>().AddAsync(RegionDomainModel);
           //await _context.SaveChangesAsync();

            var RegionDto = new RegionDTO()
            {
                Id = RegionDomainModel.Id,
                Code = RegionDomainModel.Code,
                Name = RegionDomainModel.Name,
                RegionImgUrl =RegionDomainModel.RegionImgUrl

            };
            return CreatedAtAction(nameof(GetRegionById), new { Id = RegionDto.Id }, RegionDto);


        }


        #endregion

        #region Update A Region
        [HttpPost("update-Region/{id:guid}")]
        
        public async  Task <IActionResult> update([FromRoute]Guid id, [FromBody] UpdateRegionDto dto)
        {
            var RegionDomainModel = new Region() { 
            Code = dto.Code,
            Name = dto.Name,
            RegionImgUrl = dto.RegionImgUrl,

            };


           RegionDomainModel = await _regionRepository.UpdateRegionAsync(id, RegionDomainModel);
            
            if (RegionDomainModel== null)
            {
                return NotFound(new { success =false , message="Not found"});
            }
            
            var regionDto = new RegionDTO()
            {
                Id = RegionDomainModel.Id,
                Code = RegionDomainModel.Code,
                RegionImgUrl = RegionDomainModel.RegionImgUrl,
            };
            return Ok(regionDto);
        }

        #endregion

        #region Delete A Region
        [HttpDelete("Region-Delete/{id}")]
        public async Task <IActionResult> Delete(Guid id)
        {
             var RegionDomainModel=await _regionRepository.DeleteRegionAsync(id);

            if (RegionDomainModel == null)
            {
                return NotFound(new { success = false, message = "Region Not Found" });
            }
             
            return Ok();

        }

        #endregion
    }
}
