using SevenConsole.Reports.Reports.Models;

namespace SevenConsole.Reports.Producers
{
    public interface IProducerFactory<TRecord>
    {
        IProducer<TRecord> GetProducer(ReportRequest request);
    }
}
