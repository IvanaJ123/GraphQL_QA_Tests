namespace FeeCalculationEngine.Models
{
    public class TransactionBatchResponse
    {
        public List<TransactionResult> Results { get; set; } = new List<TransactionResult>();
    }
}
