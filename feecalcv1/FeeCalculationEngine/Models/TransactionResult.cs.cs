namespace FeeCalculationEngine.Models
{
    public class TransactionResult
    {
        public string TransactionId { get; set; }
        public decimal Fee { get; set; }
        public List<string> AppliedRules { get; set; }
    }
}
