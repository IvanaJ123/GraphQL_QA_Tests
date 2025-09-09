using FeeCalculationEngine.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    // Constructor injection via DI
    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // POST /batch endpoint
    [HttpPost("batch")]
    public async Task<IActionResult> CalculateBatchFees([FromBody] TransactionBatchRequest batchRequest)
    {
        if (batchRequest?.Transactions == null || !batchRequest.Transactions.Any())
            return BadRequest("Batch must contain at least one transaction.");

        if (batchRequest.Transactions.Count > 1000)
            return BadRequest("Batch size cannot exceed 1000 transactions.");

        // Here you call the service to process the batch
        var results = await _transactionService.CalculateBatchFeesAsync(batchRequest.Transactions);

        return Ok(new TransactionBatchResponse { Results = results });
    }
}
