using FeeCalculationEngine.Models;
using FeeCalculationEngine.Services.RuleEngine;

namespace FeeCalculationEngine.Services
{
    public class FeeCalculator : IFeeCalculator
    {
        private readonly List<IRule> _rules;

        public FeeCalculator()
        {
            _rules = new List<IRule>
            {
                new Rule1(),
                new Rule2(),
                new Rule3()
            };
        }

        public TransactionResult CalculateFee(TransactionRequest request)
        {
            decimal totalFee = 0;
            List<string> appliedRules = new List<string>();

            foreach (var rule in _rules)
            {
                if (rule.IsMatch(request))
                {
                    var fee = rule.CalculateFee(request);

                    // Rule3 is discount; handled after all fees
                    if (rule.RuleId != "#3")
                        totalFee += fee;

                    appliedRules.Add(rule.RuleId);
                }
            }

            // Apply 1% discount if Rule3 was matched
            if (appliedRules.Contains("#3"))
            {
                totalFee *= 0.99m;
            }

            return new TransactionResult
            {
                TransactionId = request.TransactionId,
                Fee = Math.Round(totalFee, 2),
                AppliedRules = appliedRules
            };
        }
    }
}
