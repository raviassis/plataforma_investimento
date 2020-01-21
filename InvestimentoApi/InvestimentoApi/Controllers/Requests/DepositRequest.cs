using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.Controllers.Requests
{
    public class Transaction
    {
        public string Id { get; set; }
        public decimal Value { get; set; }
    }
}
