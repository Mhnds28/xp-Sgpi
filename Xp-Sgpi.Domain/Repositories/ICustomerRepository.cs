using Xp_Sgpi.Domain.Entities;

namespace Xp_Sgpi.Domain.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task UpdateAsync(Customer? customer);
    Task<bool> CustomerExistsAsync(string email, Guid id);
    Task<Customer?> GetByIdAsync(Guid id);
    Task<bool> HasAmountToOrder(Guid id, int quantity, decimal price);
}