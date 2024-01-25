using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sentry;
using Serilog;
using System.Net.Http;
using System.Net;
using System;
using Serilog.Events;

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
                        o.Debug = true;
                        o.TracesSampleRate = 1.0;
                        o.IncludeActivityData = true;
                        o.CaptureFailedRequests = true;
                        o.SetBeforeSend((@event, hint) =>
                        {
                            if (hint.Items.TryGetValue(HintTypes.HttpResponseMessage, out var responseHint))
                            {
                                var response = (HttpResponseMessage)responseHint!;
                                var request = response.RequestMessage!;

                                var statusCode = response.StatusCode;
                                if (statusCode == HttpStatusCode.Unauthorized)
                                {
                                    @event.Contexts["Unauthorized"] = request.RequestUri.GetComponents(
                                        UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped
                                        );
                                }

                                if (statusCode == HttpStatusCode.BadRequest)
                                {
                                    @event.Contexts["Bad Request"] = request.RequestUri.GetComponents(
                                        UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped
                                        );
                                }

                                if (statusCode == HttpStatusCode.InternalServerError)
                                {
                                    @event.Contexts["Internal Server Error"] = request.RequestUri.GetComponents(
                                        UriComponents.HttpRequestUrl, UriFormat.SafeUnescaped
                                        );
                                }
                            }

                            // return the modified event
                            return @event;
                        });
                    });

                    Log.Logger = new LoggerConfiguration()
                        .WriteTo.Sentry(o =>
                        {
                            o.MinimumBreadcrumbLevel = LogEventLevel.Information;
                            o.MinimumEventLevel = LogEventLevel.Warning;
                        })
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(webBuilder => {
                    webBuilder.ClearProviders();
                    webBuilder.AddDebug();
                    webBuilder.AddConsole();
                });
    }
}
