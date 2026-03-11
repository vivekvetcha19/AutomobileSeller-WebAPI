using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.DTO.Service;
using AutomobileSeller.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AutomobileSeller.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceHistoryController : ControllerBase
    {
        private readonly IServiceHistoryService _serviceHistoryService;
        private readonly IMapper _mapper;

        public ServiceHistoryController(
            IServiceHistoryService serviceHistoryService,
            IMapper mapper)
        {
            _serviceHistoryService = serviceHistoryService;
            _mapper = mapper;
        }

        // GET: api/ServiceHistory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _serviceHistoryService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<ServiceResponseDto>>(services);

            return Ok(response);
        }

        // GET: api/ServiceHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceHistoryService.GetByIdAsync(id);

            if (service == null)
                return NotFound();

            var response = _mapper.Map<ServiceResponseDto>(service);

            return Ok(response);
        }

        // POST: api/ServiceHistory
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateDto dto)
        {
            var serviceHistory = _mapper.Map<ServiceHistory>(dto);

            var created = await _serviceHistoryService.CreateAsync(serviceHistory);

            if (created == null)
                return BadRequest("Invalid CustomerId or CarModelId.");

            var response = _mapper.Map<ServiceResponseDto>(created);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }
    }
}