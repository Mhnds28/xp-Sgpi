using Microsoft.EntityFrameworkCore;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;
using Xp_Sgpi.Infrastructure.Data;

namespace Xp_Sgpi.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly Xp_SgpiDbContext _context;

    public TransactionRepository(Xp_SgpiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.FindAsync(id);
    }

    public async Task AddAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction transaction)
    {
        _context.Entry(transaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}