using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Application.DTOs.Account;

namespace Xp_Sgpi.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
    }
}
