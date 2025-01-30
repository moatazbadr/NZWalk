using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Data;
using NZWalks2.API.DTOS;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;
        }

        #region Getting All Regions

        [HttpGet("GetAll")]
        public IActionResult GetAllRegions()
        {

            var Regions = _context.Set<Region>().ToList();

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
        public IActionResult GetRegionById(Guid id)
        {
            var RegionDomain = _context.Set<Region>().FirstOrDefault(x => x.Id == id);

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
        public IActionResult CreateRegion ([FromBody]AddRegionDto dto)
        {
            var RegionDomainModel = new Region()
            {
                Code = dto.Code,
                Name = dto.Name,
                RegionImgUrl = dto.RegionImgUrl
            };

            _context.Set<Region>().Add(RegionDomainModel);
            _context.SaveChanges();

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
        
        public IActionResult update([FromRoute]Guid id, [FromBody] UpdateRegionDto dto)
        {
            var RegionDomainModel = _context.Set<Region>().FirstOrDefault(x => x.Id == id);
            if (RegionDomainModel== null)
            {
                return NotFound(new { success =false , message="Not found"});
            }
            //var RegionDto = new UpdateRegionDto()
            //{
            //    Code = dto.Code,
            //    Name = dto.Name,
            //    RegionImgUrl = dto.RegionImgUrl
            //};
            RegionDomainModel.Code=dto.Code;    
            RegionDomainModel.Name=dto.Name;    
            RegionDomainModel.RegionImgUrl = dto.RegionImgUrl;

            _context.SaveChanges();

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
        public IActionResult Delete(Guid id)
        {
            var RegionDomainModel = _context.Set<Region>().FirstOrDefault(x => x.Id == id);

            if (RegionDomainModel == null)
            {
                return NotFound(new { success = false, message = "Region Not Found" });
            }
            _context.Set<Region>().Remove(RegionDomainModel);
            _context.SaveChanges();
            return Ok();

        }

        #endregion
    }
}
