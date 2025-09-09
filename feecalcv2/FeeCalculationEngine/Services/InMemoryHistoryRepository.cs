using FeeCalculationEngine.Models;
namespace FeeCalculationEngine.Services;

public class InMemoryHistoryRepository : IHistoryRepository
{
    private readonly List<TransactionHistory> _history = new();
    private readonly object _lock = new();  // to keep it thread-safe

    public Task SaveAsync(TransactionHistory historyEntry)
    {
        lock (_lock)
        {
            _history.Add(historyEntry);
        }

        return Task.CompletedTask;
    }

    public Task<List<TransactionHistory>> GetAllAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_history.ToList());
        }
    }
}
