using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Models
{
    public class QuoteUser
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string QuoteId { get; set; }
        public Quote Quote { get; set; }
        public int Number { get; set; }
    }
}
