using System.ComponentModel.DataAnnotations;

namespace FeeCalculationEngine.Models
{
    public class TransactionResult
    {
        [Key]
        public string TransactionId { get; set; }
        public decimal Fee { get; set; }
        public List<string> AppliedRules { get; set; }
    }
}
