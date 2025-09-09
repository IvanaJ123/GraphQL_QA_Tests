using FeeCalculationEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace FeeCalculationEngine.Data
{
    public class HistoryStorage
    {
        private readonly AppDbContext _dbContext;

        public HistoryStorage(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddToHistory(TransactionRequest request, TransactionResult result)
        {
            var history = new TransactionHistory
            {
                RequestJson = JsonSerializer.Serialize(request),
                ResultJson = JsonSerializer.Serialize(result),
                Timestamp = DateTime.UtcNow
            };

            _dbContext.TransactionHistories.Add(history);
            _dbContext.SaveChanges();
        }

        public List<TransactionHistory> GetHistory()
        {
            return _dbContext.TransactionHistories
            .Select(h => new TransactionHistory
            {
                 RequestJson = h.RequestJson,
                 ResultJson = h.ResultJson,
                 Timestamp = h.Timestamp
            }).ToList();
        }
    }
}
