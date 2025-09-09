namespace FeeCalculationEngine.Models
{
    public class TransactionRequest
    {
        public string TransactionId { get; set; }
        public string Type { get; set; } // POS, e-commerce, etc.
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public bool IsInternational { get; set; }

        public ClientInfo Client { get; set; }
    }

    public class ClientInfo
    {
        public string ClientId { get; set; }
        public int CreditScore { get; set; }
    }
}
