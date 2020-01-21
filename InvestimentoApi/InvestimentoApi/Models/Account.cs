using InvestimentoApi.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Models
{
    public class Account
    {
        public string Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; private set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Account () { }

        public Account(string id, decimal balance, string userId, ApplicationUser user)
        {
            Id = id;
            Balance = balance;
            UserId = userId;
            User = user;
        }

        public decimal Deposit(decimal value)
        {
            if (value < 0)
                throw new NegativeDepositException();
            return Balance += value;
        }
    }
}
