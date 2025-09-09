using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Services.RuleEngine
{
    public class Rule1 : IRule
    {
        public string RuleId => "#1";

        public bool IsMatch(TransactionRequest request)
        {
            return request.Type == "POS";
        }

        public decimal CalculateFee(TransactionRequest request)
        {
            if (request.Amount <= 100)
                return 0.20m; // fixed fee
            else
                return request.Amount * 0.002m; // 0.2%
        }
    }
}
