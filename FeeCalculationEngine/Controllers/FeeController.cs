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
        private readonly HistoryStorage _historyStorage;

        public FeeController(AppDbContext dbContext)
        {
            _feeCalculator = new FeeCalculator();
            _historyStorage = new HistoryStorage(dbContext);
        }

        [HttpPost("calculate")]
        public ActionResult<TransactionResult> Calculate([FromBody] TransactionRequest request)
        {
            var result = _feeCalculator.CalculateFee(request);
            _historyStorage.AddToHistory(request, result);
            return Ok(result);
        }

        [HttpGet("history")]
        public ActionResult<List<TransactionHistory>> GetHistory()
        {
            var history = _historyStorage.GetHistory();
            return Ok(history);
        }
    }
}
