using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using InvestimentoApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly IQueryableExtensionWrapper _queryableWrapper;
        public AccountService(ApplicationDbContext context, IQueryableExtensionWrapper queryableWrapper)
        {
            _context = context;
            _queryableWrapper = queryableWrapper;
        }

        private Account GetAccount(string userId, string id = null)
        {
            if(string.IsNullOrWhiteSpace(id))
                return _queryableWrapper.FirstOrDefault(_context.Accounts, a => a.UserId == userId);
            else
                return _queryableWrapper.FirstOrDefault(_context.Accounts, a => a.Id == id && a.UserId == userId);
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
            if(account != null)
            {
                account.Deposit(value);
                return Save(account);
            }

            return account;
        }        

        public Account DrawOut(string userId, string id, decimal value)
        {
            var account = GetAccount(userId, id);
            if (account != null)
            {
                account.DrawOut(value);
                return Save(account);
            }

            return account;

        }

        public Account GetAccount(string userId)
        {
            return GetAccount(userId, null);
        }
    }
}
