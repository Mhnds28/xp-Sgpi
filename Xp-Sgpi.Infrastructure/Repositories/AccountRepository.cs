using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;
using Xp_Sgpi.Infrastructure.Data;

namespace Xp_Sgpi.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Xp_SgpiDbContext _context;

        public AccountRepository(Xp_SgpiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
