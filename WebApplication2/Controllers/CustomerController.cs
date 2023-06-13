using CME_Task.Common.DTO;
using CME_Task.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace CME_TaskAPI.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.Save(customer);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }

}
