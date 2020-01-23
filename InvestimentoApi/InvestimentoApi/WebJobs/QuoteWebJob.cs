using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Websocket.Client;
using Newtonsoft.Json;
using System.Threading;
using InvestimentoApi.Models;
using Microsoft.Extensions.Configuration;
using InvestimentoApi.Services.Interfaces;

namespace InvestimentoApi.WebJobs
{
    public class QuoteWebJob: IQuoteWebJob
    {
        private readonly Uri _url;
        private readonly IQuoteService _quoteService;
        public QuoteWebJob(IConfiguration configuration, IQuoteService quoteService)
        {
            _url = new Uri(configuration.GetValue<string>("QuotesMockUrl"));
            _quoteService = quoteService;
        }

        public async Task Start()
        {
            var exitEvent = new ManualResetEvent(false);

            using (var client = new WebsocketClient(_url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);

                client.MessageReceived.Subscribe(msg => {
                    Console.Write($"\rMessage Received: {msg}        ");
                    SaveMessage(msg);
                });

                await client.Start();

                exitEvent.WaitOne();
            }
        }

        private void SaveMessage(ResponseMessage msg)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg.Text);
            Quote quote = new Quote()
            {
                Name = values.ElementAt(0).Key,
                Value = decimal.Parse(values.ElementAt(0).Value.ToString()),
            };
            _ = _quoteService.UpInsert(quote);
        }
    }
}
