using Microsoft.AspNetCore.Mvc;
using AutomobileSeller.Services;
using AutomobileSeller.Models;
using AutoMapper;
using AutomobileSeller.DTO.Customer;

namespace AutomobileSeller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            var response = _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);

            return Ok(response);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            var response = _mapper.Map<CustomerResponseDto>(customer);

            return Ok(response);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            var created = await _customerService.CreateAsync(customer);

            var response = _mapper.Map<CustomerResponseDto>(created);

            return CreatedAtAction(nameof(GetById),
                new { id = response.Id }, response);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerUpdateDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);

            var updated = await _customerService.UpdateAsync(id, customer);

            if (updated == null)
                return NotFound();

            var response = _mapper.Map<CustomerResponseDto>(updated);

            return Ok(response);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _customerService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}