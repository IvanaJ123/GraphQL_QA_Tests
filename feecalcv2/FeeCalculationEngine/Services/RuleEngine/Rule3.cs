using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services.RuleEngine
{
    public class Rule3 : IRule
    {
        public string RuleId => "#3";

        public bool IsMatch(TransactionRequest request)
        {
            return request.Client != null && request.Client.CreditScore > 400;
        }

        public decimal CalculateFee(TransactionRequest request)
        {
            return 0m; // Rule3 is discount, so handled separately
        }
    }
}
