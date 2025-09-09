using FeeCalculationEngine.Models;

namespace FeeCalculationEngine.Data
{
    public static class HistoryStorage
    {
        private static List<TransactionHistory> _history = new List<TransactionHistory>();

        public static void AddToHistory(TransactionRequest request, TransactionResult result)
        {
            _history.Add(new TransactionHistory
            {
                Request = request,
                Result = result,
                Timestamp = DateTime.UtcNow
            });
        }

        public static List<TransactionHistory> GetHistory()
        {
            return _history;
        }
    }
}
