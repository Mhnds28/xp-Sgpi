﻿using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Xp_Sgpi.Application.DTOs.Transaction;
using Xp_Sgpi.Application.Interfaces;

namespace Xp_Sgpi.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController(ITransactionService transactionService) : ControllerBase
{
    [HttpGet]
    [SwaggerResponse(200, "Uma lista de transações", typeof(IEnumerable<TransactionDto>))]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
    {
        var transactions = await transactionService.GetAllAsync();
        return Ok(transactions);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200, "Uma transação", typeof(TransactionDto))]
    [SwaggerResponse(404, "Transação não encontrada")]
    public async Task<ActionResult<TransactionDto>> GetTransaction(Guid id)
    {
        var transaction = await transactionService.GetByIdAsync(id);
        if (transaction == null) return NotFound();
        return Ok(transaction);
    }

    [HttpPost]
    [SwaggerResponse(201, "Transação criada com sucesso", typeof(CreateTransactionDto))]
    public async Task<ActionResult<CreateTransactionDto>> PostTransaction(CreateTransactionDto transactionDto)
    {
        var transactionId = await transactionService.AddAsync(transactionDto);

        return CreatedAtAction(nameof(GetTransaction), new { id = transactionId }, transactionDto);
    }

    [HttpPut("{id}")]
    [SwaggerResponse(204, "Transação atualizada com sucesso")]
    [SwaggerResponse(400, "ID da transação não corresponde ao ID fornecido")]
    public async Task<IActionResult> PutTransaction(Guid id, TransactionDto transactionDto)
    {
        if (id != transactionDto.TransactionId) return BadRequest();

        await transactionService.UpdateAsync(transactionDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(204, "Transação deletada com sucesso")]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        await transactionService.DeleteAsync(id);
        return NoContent();
    }
}