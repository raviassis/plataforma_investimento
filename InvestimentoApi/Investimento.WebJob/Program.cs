using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

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

                client.MessageReceived.Subscribe(msg => Console.WriteLine($"Message received: {msg}"));
                client.Start();

                Task.Run(() => client.Send("{ message }"));

                exitEvent.WaitOne();
            }


        }
    }
}
