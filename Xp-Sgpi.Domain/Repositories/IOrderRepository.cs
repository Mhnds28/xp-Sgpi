using System.Linq.Expressions;
using Xp_Sgpi.Domain.Entities;

namespace Xp_Sgpi.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(Guid id);
    Task<bool> AnyAsync(Func<Order?, bool> predicate);
    Task<Order> FindAsync(Expression<Func<Order, bool>> predicate, bool asNoTracking = false);
    Task<IEnumerable<Order>> FindAllAsync(Expression<Func<Order, bool>> predicate, bool asNoTracking = false);
}