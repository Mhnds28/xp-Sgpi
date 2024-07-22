using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Domain.Entities;

namespace Xp_Sgpi.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
    }
}
