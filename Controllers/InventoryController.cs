using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.Models;
using AutoMapper;
using AutomobileSeller.DTO.Inventory;

namespace AutomobileSeller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ICarModelService _carModelService;
        private readonly IMapper _mapper;

        public InventoryController(
            IInventoryService inventoryService,
            ICarModelService carModelService,
            IMapper mapper)
        {
            _inventoryService = inventoryService;
            _carModelService = carModelService;
            _mapper = mapper;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _inventoryService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<InventoryResponseDto>>(inventories);

            return Ok(response);
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _inventoryService.GetByIdAsync(id);

            if (inventory == null)
                return NotFound();

            var response = _mapper.Map<InventoryResponseDto>(inventory);

            return Ok(response);
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> Create(InventoryCreateDto dto)
        {
            var inventory = _mapper.Map<Inventory>(dto);

            var created = await _inventoryService.CreateAsync(inventory);

            if (created == null)
            {
                // First check if CarModel exists
                var carModelCheck = await _carModelService.GetByIdAsync(dto.CarModelId!.Value);

                if (carModelCheck == null)
                    return NotFound("CarModel does not exist.");

                return BadRequest("Inventory already exists for this CarModel.");
            }

            var response = _mapper.Map<InventoryResponseDto>(created);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InventoryUpdateDto dto)
        {
            var inventory = _mapper.Map<Inventory>(dto);

            var updated = await _inventoryService.UpdateAsync(id, inventory);

            if (updated == null)
                return NotFound();

            var response = _mapper.Map<InventoryResponseDto>(updated);

            return Ok(response);
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _inventoryService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}