using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestimentoApi.WebJobs
{
    public interface IQuoteWebJob
    {
        Task Start();
    }
}
