using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SevenConsole.Configuration;
using SevenConsole.Reports.Reports.UserReport;
using AutoMapper;
using SevenConsole.Reports.Extensions;

namespace SevenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure setup
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            // Register dependencies
            var serviceProvider = new ServiceCollection()
                .AddOptions()
                .Configure<AppSettings>(config)
                .AddAutoMapper()
                .AddReports()
                .AddTransient<Report>()
                .AddTransient<UserReportGenerator>()
                .BuildServiceProvider();

            // Run the report
            serviceProvider
                .GetService<Report>()
                .GenerateReport();

            Console.ReadKey();
        }
    }
}
