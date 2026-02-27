using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.DTO.Selling;
using AutomobileSeller.Models;
using AutoMapper;

namespace AutomobileSeller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellingController : ControllerBase
    {
        private readonly ISellingService _sellingService;
        private readonly IMapper _mapper;

        public SellingController(
            ISellingService sellingService,
            IMapper mapper)
        {
            _sellingService = sellingService;
            _mapper = mapper;
        }

        // GET: api/Selling
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _sellingService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<SellingResponseDto>>(sales);

            return Ok(response);
        }

        // GET: api/Selling/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _sellingService.GetByIdAsync(id);

            if (sale == null)
                return NotFound();

            var response = _mapper.Map<SellingResponseDto>(sale);

            return Ok(response);
        }

        // POST: api/Selling
        [HttpPost]
        public async Task<IActionResult> Create(SellingCreateDto dto)
        {
            var selling = _mapper.Map<SellingHistory>(dto);

            var created = await _sellingService.CreateAsync(selling);

            if (created == null)
                return BadRequest("Invalid sale. Check customer, car model, or stock availability.");

            var response = _mapper.Map<SellingResponseDto>(created);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }
    }
}