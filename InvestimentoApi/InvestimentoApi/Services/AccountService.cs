using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Account Deposit(string userId, string id, decimal value)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == id && a.UserId == userId);

            account.Deposit(value);

            _context.Accounts.Update(account);
            _context.SaveChanges();

            return account;
        }

        public Account DrawOut(string userId, string id, decimal value)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string userId)
        {
            return _context.Accounts.FirstOrDefault(a => a.UserId == userId);
        }
    }
}
