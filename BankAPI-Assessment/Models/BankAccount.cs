
namespace BankAPI_Assessment.Models
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}

