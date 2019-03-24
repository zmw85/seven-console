using SevenConsole.Reports.Reports.Models;

namespace SevenConsole.Reports.Producers
{
    public class ProducerFactory<TRecord> : IProducerFactory<TRecord>
    {
        private readonly IProducer<TRecord> _jsonProducer;

        public ProducerFactory(IProducer<TRecord> jsonProducer)
        {
            _jsonProducer = jsonProducer;
        }

        public IProducer<TRecord> GetProducer(ReportRequest request)
        {
            switch (request.Format)
            {
                case Enums.DataFormats.JSON:
                    return _jsonProducer;
                case Enums.DataFormats.XML:
                case Enums.DataFormats.CSV:
                default:
                    return null;
            }
        }
    }
}
