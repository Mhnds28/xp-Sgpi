using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Xp_Sgpi.Application.DTOs.Customer;
using Xp_Sgpi.Application.DTOs.Order;
using Xp_Sgpi.Application.Interfaces;

namespace Xp_Sgpi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    [SwaggerResponse(200, "cliente obtido com sucesso", typeof(OrderDto))]
    [SwaggerResponse(404, "cliente não encontrado")]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await customerService.GetAllAsync();
        return Ok(customers);
    }


    [HttpPut("{id}")]
    [SwaggerResponse(204, "cliente atualizado com sucesso")]
    [SwaggerResponse(400, "Dados inválidos")]
    public async Task<IActionResult> PutCustomer(Guid id, CustomerDto customerDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != customerDto.CustomerId)
            return BadRequest(new { message = "O ID do cliente fornecido não corresponde ao ID na URL." });

        var customerExists = await customerService.CustomerExistsAsync(customerDto.Email, customerDto.CustomerId);

        if (customerExists) return Conflict(new { message = "Um cliente com este email já existe." });

        await customerService.UpdateAsync(customerDto);

        return NoContent();
    }
}