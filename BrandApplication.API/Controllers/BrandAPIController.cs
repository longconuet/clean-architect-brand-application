using BrandApplication.Business.DTOs;
using BrandApplication.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrandApplication.API.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandAPIController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandAPIController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllAsync();
            return Ok(brands);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BrandDto>> GetBrandByID(int id)
        {
            if (id < 1)
            {
                return BadRequest("Id must be greater than 0");
            }

            return Ok(await _brandService.GetByIdAsync(id));
        }
    }
}
