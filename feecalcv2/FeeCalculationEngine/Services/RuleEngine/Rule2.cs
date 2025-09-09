using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services.RuleEngine
{
    public class Rule2 : IRule
    {
        public string RuleId => "#2";

        public bool IsMatch(TransactionRequest request)
        {
            return request.Type == "e-commerce";
        }

        public decimal CalculateFee(TransactionRequest request)
        {
            var fee = (request.Amount * 0.018m) + 0.15m;
            return fee > 120 ? 120 : fee; // cap fee at €120
        }
    }
}
