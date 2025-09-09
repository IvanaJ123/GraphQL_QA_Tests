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

        [HttpPost("batchCalculateFees")]
        public async Task<ActionResult<TransactionBatchResponse>> BatchCalculateFees([FromBody] List<TransactionRequest> requests)
        {
            var response = await _feeCalculator.CalculateBatchFeesAsync(requests);
            return Ok(response);
        }

    }
}
