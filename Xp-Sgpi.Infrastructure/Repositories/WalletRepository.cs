﻿using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;
using Xp_Sgpi.Infrastructure.Data;

namespace Xp_Sgpi.Infrastructure.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly Xp_SgpiDbContext _context;

    public WalletRepository(Xp_SgpiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Wallet?>> GetAllAsync()
    {
        return await _context.Wallets.ToListAsync();
    }

    public async Task<Wallet?> GetByIdAsync(Guid id)
    {
        return await _context.Wallets.FindAsync(id);
    }

    public async Task AddAsync(Wallet? wallet)
    {
        _context.Wallets.Add(wallet);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Wallet wallet)
    {
        _context.Entry(wallet).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var wallet = await _context.Wallets.FindAsync(id);
        if (wallet != null)
        {
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> AnyAsync(Func<Wallet?, bool> predicate)
    {
        return await Task.FromResult(_context.Wallets.Any(predicate));
    }

    public async Task<Wallet?> GetByCustomerIdAndAssetIdAsync(Guid customerId, Guid assetId)
    {
        return await _context.Wallets
            .FirstOrDefaultAsync(w => w!.CustomerId == customerId && w.AssetId == assetId);
    }

    public async Task<bool> HasAssetsToOrder(Guid id, Guid assetId, int quantity)
    {
        var wallet = await GetByCustomerIdAndAssetIdAsync(id, assetId);

        return wallet?.Quantity >= quantity;
    }
}