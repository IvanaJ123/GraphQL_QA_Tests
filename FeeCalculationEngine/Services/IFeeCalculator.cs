using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services
{
    public interface IFeeCalculator
    {
        TransactionResult CalculateFee(TransactionRequest request);
    }
}
