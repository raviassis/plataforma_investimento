using InvestimentoApi.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public Account Account { get; set; }
        public List<QuoteUser> QuotesUser { get; set; }

        public QuoteUser Buy(Quote quote, int number)
        {
            CheckNumber(number);

            var value = quote.Value * number;
            Account.DrawOut(value);

            var quoteUser = new QuoteUser()
            {
                Id = Guid.NewGuid().ToString(),
                QuoteId = quote.Id,
                UserId = Id,
                Number = number
            };

            return Add(quoteUser);
        }

        private static void CheckNumber(int number)
        {
            if (number <= 0)
                throw new LessOrEqualZeroException();
        }

        private QuoteUser Add(QuoteUser quoteUser)
        {
            Func<QuoteUser, bool> predicate = (q) => q.QuoteId == quoteUser.QuoteId;

            if (QuotesUser.Any(predicate))
            {
                var quoteU = QuotesUser.First(predicate);
                quoteU.Number += quoteUser.Number;
                return quoteU;
            }
            else
            {
                QuotesUser.Add(quoteUser);
                return quoteUser;
            }
        }

        public QuoteUser Sell(Quote quote, int number)
        {
            CheckNumber(number);
            OwnQuotesToSell(quote, number);
            var quoteUser = Remove(quote, number);
            var value = quote.Value * number;
            Account.Deposit(value);
            return quoteUser;
        }

        private QuoteUser Remove(Quote quote, int number)
        {
            var quoteUser = QuotesUser.FirstOrDefault(q => q.QuoteId == quote.Id);
            quoteUser.Number -= number;
            if (quoteUser.Number == 0)
            {
                QuotesUser.Remove(quoteUser);
            }
            return quoteUser;
        }

        private void OwnQuotesToSell(Quote quote, int number)
        {
            var quoteUser = QuotesUser.FirstOrDefault(q => q.QuoteId == quote.Id);

            if (quoteUser == null || quoteUser.Number < number)
            {
                throw new InsufficientQuotesException();
            }
        }
    }
}
