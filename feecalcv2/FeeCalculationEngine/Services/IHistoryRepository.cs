using FeeCalculationEngine.Models;
namespace FeeCalculationEngine.Services
{
    
    public interface IHistoryRepository
    {
        Task SaveAsync(TransactionHistory historyEntry);
        Task<List<TransactionHistory>> GetAllAsync();
    }

}
