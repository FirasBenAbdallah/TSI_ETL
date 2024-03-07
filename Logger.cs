using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;

namespace TSI_ERP_ETL
{
    public static class Logger
    {
        public static ServiceProvider Log()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole(options =>
                    {
                        options.FormatterName = nameof(CustomConsoleFormatter);
                    })
                    .AddConsoleFormatter<CustomConsoleFormatter, ConsoleFormatterOptions>();
                })
                .BuildServiceProvider();

            return serviceProvider;
        }
    }

    public class CustomConsoleFormatter : ConsoleFormatter
    {
        public CustomConsoleFormatter() : base(nameof(CustomConsoleFormatter))
        {
        }

        public override void Write<TState>(in LogEntry<TState> entry, IExternalScopeProvider? scopeProvider, TextWriter writer)
        {
            var defaultColor = Console.ForegroundColor;

            var logLevel = entry.LogLevel;
            var message = entry.Formatter(entry.State, entry.Exception);

            writer.Write($"[{DateTime.Now:dd-MMM-yyyy HH:mm:ss} ");
            writer.Write($"{logLevel.ToString()[..3].ToUpperInvariant()}] ");

            Console.ForegroundColor = defaultColor;
            writer.WriteLine($" {message}");
        }
    }
}
