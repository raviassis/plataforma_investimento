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
    public class QuoteService : IQuoteService
    {
        private readonly ApplicationDbContext _context;
        private readonly IQueryableExtensionWrapper _queryableWrapper;
        public QuoteService(ApplicationDbContext context, IQueryableExtensionWrapper queryableWrapper)
        {
            _context = context;
            _queryableWrapper = queryableWrapper;
        }

        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes.AsEnumerable();
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
