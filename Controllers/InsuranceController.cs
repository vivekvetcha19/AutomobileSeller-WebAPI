using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.DTO.Insurance;
using AutomobileSeller.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace AutomobileSeller.Controllers
{
    [Authorize(Roles = "Admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;
        private readonly IMapper _mapper;

        public InsuranceController(IInsuranceService insuranceService, IMapper mapper)
        {
            _insuranceService = insuranceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insurances = await _insuranceService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<InsuranceResponseDto>>(insurances);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var insurance = await _insuranceService.GetByIdAsync(id);

            if (insurance == null)
                return NotFound();

            var response = _mapper.Map<InsuranceResponseDto>(insurance);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceCreateDto dto)
        {
            var insurance = _mapper.Map<Insurance>(dto);

            var created = await _insuranceService.CreateAsync(insurance);

            if (created == null)
                return BadRequest("Invalid data. Check customer, car model, or dates.");

            var response = _mapper.Map<InsuranceResponseDto>(created);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }
    }
}