using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;
using Newtonsoft.Json;
using InvestimentoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Investimento.WebJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start().Wait();
        }

        private static async Task Start()
        {
            var exitEvent = new ManualResetEvent(false);
            var url = new Uri("ws://192.168.99.100:8080/quotes");

            using (var client = new WebsocketClient(url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.ReconnectionHappened.Subscribe(info =>
                    Console.WriteLine($"Reconnection happened, type: {info.Type}"));

                client.MessageReceived.Subscribe(msg => { 
                    Console.WriteLine($"Message received: {msg}");
                    SaveMessage(msg);
                });

                await client.Start();

                exitEvent.WaitOne();
            }
        }

        private static void SaveMessage(ResponseMessage msg)
        {
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(msg.Text);
            Quote quote = new Quote()
            {
                Name = values.ElementAt(0).Key,
                Value = decimal.Parse(values.ElementAt(0).Value.ToString()),
            };
            
        }
    }
}
