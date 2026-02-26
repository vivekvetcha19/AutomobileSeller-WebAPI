using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.Models;
using AutoMapper;
using AutomobileSeller.DTO.CarModel;

namespace AutomobileSeller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _carModelService;
        private readonly IMapper _mapper;

        public CarModelController(ICarModelService carModelService, IMapper mapper)
        {
            _carModelService = carModelService;
            _mapper = mapper;
        }

        // GET: api/CarModel
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _carModelService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<CarModelResponseDto>>(models);

            return Ok(response);
        }

        // GET: api/CarModel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _carModelService.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            var response = _mapper.Map<CarModelResponseDto>(model);

            return Ok(response);
        }

        // GET: api/CarModel/brand/2
        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> GetByBrand(int brandId)
        {
            var models = await _carModelService.GetByBrandIdAsync(brandId);

            var response = _mapper.Map<IEnumerable<CarModelResponseDto>>(models);

            return Ok(response);
        }

        // POST: api/CarModel
        [HttpPost]
        public async Task<IActionResult> Create(CarModelCreateDto dto)
        {
            var model = _mapper.Map<CarModel>(dto);

            var createdModel = await _carModelService.CreateAsync(model);

            var response = _mapper.Map<CarModelResponseDto>(createdModel);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }

        // PUT: api/CarModel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CarModelUpdateDto dto)
        {
            var model = _mapper.Map<CarModel>(dto);

            var updatedModel = await _carModelService.UpdateAsync(id, model);

            if (updatedModel == null)
                return NotFound();

            var response = _mapper.Map<CarModelResponseDto>(updatedModel);

            return Ok(response);
        }

        // DELETE: api/CarModel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _carModelService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
