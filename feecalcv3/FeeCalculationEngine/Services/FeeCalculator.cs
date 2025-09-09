using FeeCalculationEngine.Data;
using FeeCalculationEngine.Models;
using FeeCalculationEngine.Services.RuleEngine;
using System.Collections.Concurrent;

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
        public TransactionBatchResponse CalculateBatchFees(List<TransactionRequest> requests)
        {
            var results = new ConcurrentBag<TransactionResult>();

            // Process transactions in parallel
            Parallel.ForEach(requests, request =>
            {
                var result = CalculateFee(request);

                // Add to thread-safe collection
                results.Add(result);

                // Save to history - ensure thread-safe
                HistoryStorage.AddToHistory(request, result);
            });

            return new TransactionBatchResponse
            {
                Results = results.ToList()
            };
        }

        public async Task<TransactionBatchResponse> CalculateBatchFeesAsync(List<TransactionRequest> requests)
        {
            var results = new ConcurrentBag<TransactionResult>();

            var lockObj = new object();

            await Parallel.ForEachAsync(requests, async (request, ct) =>
            {
                var result = CalculateFee(request);

                results.Add(result);

                lock (lockObj)
                {
                    // Assuming HistoryStorage.AddToHistory is not thread-safe, so do it safely here
                    HistoryStorage.AddToHistory(request, result);
                }

                await Task.Yield(); // Yield to keep responsiveness if needed
            });

            return new TransactionBatchResponse
            {
                Results = results.ToList()
            };
        }


    }
}
