using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Models;
using AutomobileSeller.Services;
using AutoMapper;
using AutomobileSeller.DTO.Brand;

namespace AutomobileSeller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _brandService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<BrandResponseDto>>(brands);

            return Ok(response);
        }

        // GET: api/Brand/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            if (brand == null)
                return NotFound();

            var response = _mapper.Map<BrandResponseDto>(brand);

            return Ok(response);
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);

            var createdBrand = await _brandService.CreateAsync(brand);

            var response = _mapper.Map<BrandResponseDto>(createdBrand);

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        // PUT: api/Brand/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BrandUpdateDto dto)
        {
            var brand = _mapper.Map<Brand>(dto);

            var updatedBrand = await _brandService.UpdateAsync(id, brand);

            if (updatedBrand == null)
                return NotFound();

            var response = _mapper.Map<BrandResponseDto>(updatedBrand);

            return Ok(response);
        }

        // DELETE: api/Brand/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _brandService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
