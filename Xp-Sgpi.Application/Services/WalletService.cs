﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Application.DTOs.Order;
using Xp_Sgpi.Application.DTOs.Wallet;
using Xp_Sgpi.Application.Interfaces;
using Xp_Sgpi.Domain.Entities;
using Xp_Sgpi.Domain.Repositories;

namespace Xp_Sgpi.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IMapper _mapper;

        public WalletService(IWalletRepository walletRepository, IMapper mapper)
        {
            _walletRepository = walletRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WalletDto>> GetAllAsync()
        {
            var wallets = await _walletRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<WalletDto>>(wallets);
        }

        public async Task<WalletDto> GetByIdAsync(Guid id)
        {
            var wallet = await _walletRepository.GetByIdAsync(id);
            return _mapper.Map<WalletDto>(wallet);
        }

        public async Task<Guid> AddAsync(CreateWalletDto walletDto)
        {
            var wallet = _mapper.Map<Wallet>(walletDto);

            await _walletRepository.AddAsync(wallet);

            return wallet.WalletId;
        }

        public async Task UpdateAsync(WalletDto walletDto)
        {
            var wallet = _mapper.Map<Wallet>(walletDto);
            await _walletRepository.UpdateAsync(wallet);
        }

        public async Task DeleteAsync(Guid id)
        {
            var wallet = await _walletRepository.GetByIdAsync(id);

            if (wallet?.Quantity > 0)
                throw new InvalidOperationException("Não é possível excluir uma carteira com ativos.");

            await _walletRepository.DeleteAsync(id);
        }

        public async Task<Wallet?> GetByCustomerIdAndAssetIdAsync(Guid customerId, Guid assetId)
        {
            return await _walletRepository.GetByCustomerIdAndAssetIdAsync(customerId, assetId);
        }

        public async Task<bool> HasAssetsToOrder(Guid id, Guid assetId, int quantity)
        {
            return await _walletRepository.HasAssetsToOrder(id, assetId, quantity);
        }
    }
}
