namespace FeeCalculationEngine.Models
{
    public class TransactionHistory
    {
        public TransactionRequest Request { get; set; }
        public TransactionResult Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
