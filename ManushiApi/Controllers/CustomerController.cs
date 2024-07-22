using AutoMapper;
using ManushiApi.Entities;
using ManushiApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManushiApi.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper; 

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        return Ok(_customerService.GetAllCustomers());
    }

    [HttpGet("{id}")]
    public ActionResult<CustomerDto> GetCustomerById(int id)
    {
        var customerDto = _customerService.GetCustomerById(id);
        return customerDto != null ? Ok(customerDto) : NotFound();
    }

    [HttpPost]
    public IActionResult CreateCustomer(CustomerDto customerDto)
    {
        _customerService.AddCustomer(customerDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.Id }, customerDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, CustomerDto customerDto)
    {
        if (id != customerDto.Id)
        {
            return BadRequest(); // Mismatched IDs
        }

        if (!_customerService.UpdateCustomer(customerDto))
        {
            return NotFound(); // Customer not found
        }
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id)
    {
        var success = _customerService.DeleteCustomer(id);
        return success ? NoContent() : NotFound();
    }
}
}
