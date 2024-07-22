using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Application.DTOs.Account;
using Xp_Sgpi.Application.Interfaces;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;

namespace Xp_Sgpi.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }
    }
}
