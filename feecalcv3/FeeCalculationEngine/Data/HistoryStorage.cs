using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Data
{
    public static class HistoryStorage
    {
        private static List<TransactionHistory> _history = new List<TransactionHistory>();
        private static readonly object _lock = new object();

        public static void AddToHistory(TransactionRequest request, TransactionResult result)
        {
            lock (_lock)
            {
                _history.Add(new TransactionHistory
                {
                    Request = request,
                    Result = result,
                    Timestamp = DateTime.UtcNow
                });
            }
        }

        public static List<TransactionHistory> GetHistory()
        {
            lock (_lock)
            {
                return _history.ToList(); // Return a copy to keep encapsulation
            }
        }

    }
}
