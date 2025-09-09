using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services
{
    public interface IFeeCalculator
    {
        TransactionResult CalculateFee(TransactionRequest request);
        TransactionBatchResponse CalculateBatchFees(List<TransactionRequest> requests);
        Task<TransactionBatchResponse> CalculateBatchFeesAsync(List<TransactionRequest> requests);
    }
}
