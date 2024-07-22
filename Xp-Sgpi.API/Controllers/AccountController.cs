using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Xp_Sgpi.Application.DTOs.Account;
using Xp_Sgpi.Application.Interfaces;

namespace Xp_Sgpi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService accountService) : ControllerBase
{
    [HttpGet]
    [SwaggerResponse(200, "Lista de contas obtida com sucesso", typeof(IEnumerable<AccountDto>))]
    
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccounts()
    {
        var accounts = await accountService.GetAllAsync();
        return Ok(accounts);
    }
}