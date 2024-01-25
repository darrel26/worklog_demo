using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worklog_demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseSentry(o =>
                    {
                        o.Dsn = "https://b657054cbca9659b6211a2cc98efdc0a@o4506634167975936.ingest.sentry.io/4506634172301312";
                        o.Debug = true;
                        o.TracesSampleRate = 1.0;
                    });
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(webBuilder => {
                    webBuilder.ClearProviders();
                    webBuilder.AddDebug();
                    webBuilder.AddConsole();
                });
    }
}
