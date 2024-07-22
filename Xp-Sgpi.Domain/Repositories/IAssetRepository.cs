using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xp_Sgpi.Domain.Entities;

namespace Xp_Sgpi.Domain.Repositories
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset?>> GetAllAsync();
        Task<Asset> GetByIdAsync(Guid id);
        Task AddAsync(Asset? asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(Guid id);
        Task<bool> AssetExistsAsync(string cod, Guid? id = null);
        Task<Asset?> FindAsync(Expression<Func<Asset?, bool>> predicate, bool asNoTracking = false);
        Task<IEnumerable<Asset?>> FindAllAsync(Expression<Func<Asset?, bool>> predicate);
    }
}
