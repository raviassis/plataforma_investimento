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
using Microsoft.Extensions.DependencyInjection;
using InvestimentoApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using InvestimentoApi.Services.Interfaces;
using InvestimentoApi.Services;
using InvestimentoApi.WebJobs;
using InvestimentoApi.Shared;

namespace Investimento.WebJob
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Builder Configuration");
            var config = new ConfigurationBuilder()
                                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                                .AddJsonFile("appsettings.json")
                                .Build();

            Console.WriteLine("Builder DI");
            var serviceProvider = new ServiceCollection()
                                        .AddDbContext<ApplicationDbContext>(options =>
                                            options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                                        )
                                        .AddSingleton<IConfiguration>(config)
                                        .AddScoped<IQuoteService, QuoteService>()
                                        .AddSingleton<IQuoteWebJob, QuoteWebJob>()
                                        .AddSingleton<IQueryableExtensionWrapper, QueryableExtensionWrapper>()
                                        .BuildServiceProvider();


            Console.WriteLine("Get WebJob");
            var job = serviceProvider.GetService<IQuoteWebJob>();

            Console.WriteLine("Start");
            Console.Write("\n\n\n");
            Console.WriteLine("Press any key to exit...");
            Console.CursorTop -= 3; 
            Task.Run(() => job.Start());

            Console.ReadKey();
            Console.CursorTop += 4;
        }

    }
}
