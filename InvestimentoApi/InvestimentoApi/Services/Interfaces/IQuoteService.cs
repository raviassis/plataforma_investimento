using InvestimentoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Services.Interfaces
{
    public interface IQuoteService
    {
        Task<Quote> UpInsert(Quote quote);

        IEnumerable<Quote> GetQuotes();
    }
}
