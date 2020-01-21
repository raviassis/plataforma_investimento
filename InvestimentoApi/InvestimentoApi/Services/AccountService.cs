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

        private Account GetAccount(string userId, string id = null)
        {
            if(string.IsNullOrWhiteSpace(id))
                return _context.Accounts.FirstOrDefault(a => a.UserId == userId);
            else
                return _context.Accounts.FirstOrDefault(a => a.Id == id && a.UserId == userId);
        }

        private Account Save(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }

        public Account Deposit(string userId, string id, decimal value)
        {
            var account = GetAccount(userId, id);
            account.Deposit(value);
            return Save(account);
        }        

        public Account DrawOut(string userId, string id, decimal value)
        {
            var account = GetAccount(userId, id);
            account.DrawOut(value);
            return Save(account);
        }

        public Account GetAccount(string userId)
        {
            return GetAccount(userId, null);
        }
    }
}
