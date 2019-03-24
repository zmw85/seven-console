using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.Reports.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenConsole.Reports.Producers
{
    public interface IProducer<TRecord>
    {
        Task<bool> ProcessData(ReportRequest request);

        Producer<TRecord> AddConsumer(IDataConsumer<TRecord> consumer);

        Producer<TRecord> AddConsumer(IEnumerable<IDataConsumer<TRecord>> consumers);
    }
}
