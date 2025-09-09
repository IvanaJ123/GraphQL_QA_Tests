using Microsoft.AspNetCore.Mvc;
using FeeCalculationEngine.Models;
using FeeCalculationEngine.Services;
using FeeCalculationEngine.Data;

namespace FeeCalculationEngine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly IFeeCalculator _feeCalculator;


        public FeeController()
        {
            _feeCalculator = new FeeCalculator();
        }

        [HttpPost("calculate")]
        public ActionResult<TransactionResult> Calculate([FromBody] TransactionRequest request)
        {
            var result = _feeCalculator.CalculateFee(request);
            HistoryStorage.AddToHistory(request, result);
            return Ok(result);
        }

        [HttpGet("history")]
        public ActionResult<List<TransactionHistory>> GetHistory()
        {
            var history = HistoryStorage.GetHistory();
            return Ok(history);
        }

        [HttpPost("batch")]
        public async Task<IActionResult> CalculateBatchFees([FromBody] TransactionBatchRequest batchRequest)
        {
            if (batchRequest?.Transactions == null || !batchRequest.Transactions.Any())
                return BadRequest("Batch must contain at least one transaction.");

            if (batchRequest.Transactions.Count > 1000)
                return BadRequest("Batch size cannot exceed 1000 transactions.");

            var results = await _transactionService.CalculateBatchFeesAsync(batchRequest.Transactions);

            return Ok(new TransactionBatchResponse { Results = results });
        }

    }
}
