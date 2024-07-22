using Xp_Sgpi.Application.DTOs.Customer;

namespace Xp_Sgpi.Application.Interfaces;

public interface ICustomerService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task UpdateAsync(CustomerDto customerDto);
    Task<bool> CustomerExistsAsync(string email, Guid id);
    Task<bool> HasAmountToOrder(Guid id, int quantity, decimal price);
}