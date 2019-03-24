using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.Producers;
using SevenConsole.Reports.Reports.UserReport.Consumers;
using SevenConsole.Reports.Reports.UserReport.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenConsole.Reports.Reports.UserReport
{
    public class UserReportGenerator : IReportGenerator
    {
        private readonly IProducerFactory<User> _producerFactory;

        public UserReportGenerator(IProducerFactory<User> producerFactory)
        {
            _producerFactory = producerFactory;
        }

        public async Task GenerateReport(UserReportRequest request)
        {
            var consumers = new List<IDataConsumer<User>>()
            {
                new FindUserById(request.UserId),
                new GetUserNamesByAge(request.UserAge).SetMaxResultLines(50),
                new CalculateGenderByAge()
            };

            var success = await _producerFactory.GetProducer(request)
                .AddConsumer(consumers)
                .ProcessData(request)
                .ConfigureAwait(false);

            if (success)
            {
                PrintResults(consumers);
            }
        }

        /// <summary>
        /// Method for ouputing results to console
        /// </summary>
        private void PrintResults(List<IDataConsumer<User>> consumers)
        {
            foreach (var consumer in consumers)
            {
                consumer.PrintResult();
            }
        }
    }
}
