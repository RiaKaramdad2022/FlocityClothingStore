using FlocityClothingStore.Server.Services.Customer;
using FlocityClothingStore.Shared.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlocityClothingStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<CustomerListItem>> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return customers.ToList();
        }
   
        [HttpGet("{id}")]
        public async Task<IActionResult> Customer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreate model)
        {
            if (model == null) return BadRequest();

            bool wasCreated = await _customerService.CreateCustomerAsync(model);

            if (wasCreated)
                return Ok();
            else return UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CustomerEdit model)
        {
            if (model == null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();

            bool wasSucessful = await _customerService.UpdateCustomerAsync(model);

            if (wasSucessful) return Ok();
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();

            bool wasSucessful = await _customerService.DeleteCustomerAsync(id);
            if (!wasSucessful) return BadRequest();
            return Ok();
        }
    }
}
