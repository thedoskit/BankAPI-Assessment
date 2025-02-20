using BankAPI_Assessment.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace BankAPI_Assessment.Controllers
{
   
        [ApiController]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        public class BankController : ControllerBase
        {
            private static List<BankAccount> _accounts = new List<BankAccount>
    {
        new BankAccount { AccountNumber = "1234567890", AccountName = "Kazeem Dosunmu", Balance = 100m }
    };

            [HttpPost("Deposit")]
            public IActionResult Deposit(string accountNumber, decimal amount)
            {
                var account = _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                if (account == null) return NotFound("Account not found");
                if (amount <= 0) return BadRequest("Amount must be greater than zero");

                account.Balance += amount;
                return Ok($"Deposit successful. New balance: {account.Balance}");
            }

            [HttpPost("Withdraw")]
            public IActionResult Withdraw(string accountNumber, decimal amount)
            {
                var account = _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                if (account == null) return NotFound("Account not found");
                if (amount <= 0) return BadRequest("Amount must be greater than zero");
                if (account.Balance < amount) return BadRequest("Insufficient funds");

                account.Balance -= amount;
                return Ok($"Withdrawal successful. New balance: {account.Balance}");
            }

            [HttpGet("GetBalance/{accountNumber}")]
            public IActionResult GetBalance(string accountNumber)
            {
                var account = _accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
                if (account == null) return NotFound("Account not found");

                return Ok(account.Balance);
            }
        }
    
}
