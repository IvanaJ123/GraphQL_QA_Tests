using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services.RuleEngine
{
    public interface IRule
    {
        string RuleId { get; }
        bool IsMatch(TransactionRequest request);
        decimal CalculateFee(TransactionRequest request);
    }
}
