using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Application.DTOs.Order;
using Xp_Sgpi.Application.DTOs.Transaction;

namespace Xp_Sgpi.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(CreateTransactionDto transactionDto);
        Task UpdateAsync(TransactionDto transactionDto);
        Task DeleteAsync(Guid id);
    }
}
