using InvestimentoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(string userId);

        Account Deposit(string userId, string id, decimal value);

        Account DrawOut(string userId, string id, decimal value);
    }
}
