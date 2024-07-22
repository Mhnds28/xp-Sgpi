﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xp_Sgpi.Application.DTOs.Wallet;
using Xp_Sgpi.Application.Interfaces;
using Xp_Sgpi.Application.Services;

namespace Xp_Sgpi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletsController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletsController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        [SwaggerResponse(200, "Uma lista de carteiras", typeof(IEnumerable<WalletDto>))]
        public async Task<ActionResult<IEnumerable<WalletDto>>> GetWallets()
        {
            var wallets = await _walletService.GetAllAsync();
            return Ok(wallets);
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, "Uma carteira", typeof(WalletDto))]
        [SwaggerResponse(404, "Carteira não encontrada")]
        public async Task<ActionResult<WalletDto>> GetWallet(Guid id)
        {
            var wallet = await _walletService.GetByIdAsync(id);
            if (wallet == null) return NotFound();
            return Ok(wallet);
        }

        [HttpPost]
        [SwaggerResponse(201, "Carteira criada com sucesso", typeof(CreateWalletDto))]
        public async Task<ActionResult<CreateWalletDto>> PostWallet(CreateWalletDto walletDto)
        {
            var walletId = await _walletService.AddAsync(walletDto);
            return CreatedAtAction(nameof(GetWallet), new { id = walletId }, walletDto);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(204, "Carteira atualizada com sucesso")]
        [SwaggerResponse(400, "ID da carteira não corresponde ao ID fornecido")]
        public async Task<IActionResult> PutWallet(Guid id, WalletDto walletDto)
        {
            if (id != walletDto.WalletId) return BadRequest("O ID da carteira fornecido não corresponde ao ID na URL.");
            await _walletService.UpdateAsync(walletDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(204, "Carteira deletada com sucesso")]
        [SwaggerResponse(400, "Erro ao excluir a carteira")]
        public async Task<IActionResult> DeleteWallet(Guid id)
        {
            try
            {
                await _walletService.DeleteAsync(id);

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
