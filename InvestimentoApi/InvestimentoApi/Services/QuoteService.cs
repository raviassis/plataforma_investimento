using InvestimentoApi.Context;
using InvestimentoApi.Models;
using InvestimentoApi.Services.Interfaces;
using InvestimentoApi.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IQueryableExtensionWrapper _queryableWrapper;
        public QuoteService(ApplicationDbContext context, IQueryableExtensionWrapper queryableWrapper)
        {
            _context = context;
            _queryableWrapper = queryableWrapper;
        }

        public QuoteUser BuyQuote(string id, int number, string userId)
        {
            var user = _context.Users
                            .Include(u => u.Account)
                            .Include(u => u.QuotesUser)
                            .FirstOrDefault(u => u.Id == userId);
            var quote = _context.Quotes.FirstOrDefault(q => q.Id == id);
            var quoteUser = user.Buy(quote, number);
            _context.Update(user);
            _context.SaveChanges();
            return quoteUser;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes.AsEnumerable();
        }

        public IEnumerable<QuoteUser> OwnQuotes(string userId)
        {
            return _context.QuoteUsers.Include(q => q.Quote).Where(q => q.UserId == userId);
        }

        public QuoteUser SellQuote(string id, int number, string userId)
        {
            var user = _context.Users
                            .Include(u => u.Account)
                            .Include(u => u.QuotesUser)
                            .FirstOrDefault(u => u.Id == userId);
            var quote = _context.Quotes.FirstOrDefault(q => q.Id == id);
            var quoteUser = user.Sell(quote, number);
            _context.Update(user);
            _context.SaveChanges();
            return quoteUser;
        }

        public Task<Quote> UpInsert(Quote newQuote)
        {
            Quote quote = _queryableWrapper.FirstOrDefault(_context.Quotes, q => q.Name == newQuote.Name);

            if (quote != null)
            {
                quote.Value = newQuote.Value;
                _context.Update(quote);
            }
            else
            {
                quote = newQuote;
                quote.Id = Guid.NewGuid().ToString();
                _context.AddAsync(quote);
            }

            _context.SaveChanges();

            return Task.FromResult(quote);
        }


    }
}
