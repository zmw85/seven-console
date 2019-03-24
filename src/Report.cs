using AutoMapper;
using Microsoft.Extensions.Options;
using SevenConsole.Configuration;
using SevenConsole.Reports.Reports.UserReport;
using SevenConsole.Reports.Reports.UserReport.Models;
using System;
using System.Diagnostics;

namespace SevenConsole
{
    public class Report
    {
        private readonly AppSettings _config;
        private readonly UserReportGenerator _userReport;
        private readonly IMapper _mapper;

        public Report(
            IOptions<AppSettings> config, 
            UserReportGenerator userReport,
            IMapper mapper)
        {
            _config = config.Value;
            _userReport = userReport;
            _mapper = mapper;
        }

        public void GenerateReport()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            _userReport
                .GenerateReport(_mapper.Map<UserReportRequest>(_config.Reports.UserReport))
                .Wait();

            Console.WriteLine($"=== Time elasped: {stopWatch.Elapsed} ===");
        }
    }
}
