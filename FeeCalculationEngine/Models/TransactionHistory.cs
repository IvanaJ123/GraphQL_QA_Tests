using System.ComponentModel.DataAnnotations;

namespace FeeCalculationEngine.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; } //  PRIMARY KEY
        public string RequestJson { get; set; }
        public string ResultJson { get; set; }
        public TransactionRequest Request { get; set; }
        public TransactionResult Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
