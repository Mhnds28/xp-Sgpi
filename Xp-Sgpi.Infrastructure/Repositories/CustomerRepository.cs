using Microsoft.EntityFrameworkCore;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;
using Xp_Sgpi.Infrastructure.Data;

namespace Xp_Sgpi.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly Xp_SgpiDbContext _context;

    public CustomerRepository(Xp_SgpiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }


    public async Task UpdateAsync(Customer? customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CustomerExistsAsync(string email, Guid id)
    {
        return await _context.Customers.AnyAsync(c => c.Email == email && c.CustomerId != id);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<bool> HasAmountToOrder(Guid id, int quantity, decimal price)
    {
        var customer = await _context.Customers.FindAsync(id);

        var totalOrderValue = quantity * price;

        return customer?.Amount >= totalOrderValue;
    }
}