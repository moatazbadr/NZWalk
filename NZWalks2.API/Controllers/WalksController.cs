using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks2.API.DTOS;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        #region Create Walk
        [HttpPost("Create-Walk")]
        public async Task<IActionResult> Create([FromBody]AddWalksRequestDto dto)
        {
            var Walk=new Walk()
            {
                


            }

        }

        #endregion


    }
}
