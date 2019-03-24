using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.DataAccess;
using SevenConsole.Reports.Enums;
using SevenConsole.Reports.Reports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SevenConsole.Reports.Producers
{
    public abstract class Producer<TRecord> : IProducer<TRecord>
    {
        private readonly IDataAccessFactory _dataAccessFactory;

        public List<IDataConsumer<TRecord>> Consumers { get; private set; }

        public Producer(IDataAccessFactory dataAccessFactory)
        {
            Consumers = new List<IDataConsumer<TRecord>>();
            _dataAccessFactory = dataAccessFactory;
        }

        public Producer<TRecord> AddConsumer(IDataConsumer<TRecord> consumer)
        {
            Consumers.Add(consumer);
            return this;
        }

        public Producer<TRecord> AddConsumer(IEnumerable<IDataConsumer<TRecord>> consumers)
        {
            Consumers.AddRange(consumers);
            return this;
        }

        /// <param name="request"></param>
        /// <returns>Process success?</returns>
        public abstract Task<bool> ProcessData(ReportRequest request);

        protected bool IsFormatSupported(DataFormats format)
        {
            return format == DataFormats.JSON;
        }

        protected StreamReader GetStream(ReportRequest request)
        {
            var dataAccess = _dataAccessFactory.GetDataAccess(request);

            // Only support local file source
            if (dataAccess == null)
            {
                throw new Exception("The report only supports local file source at the moment.");
            }

            var filePath = new Uri(request.SourceUri).LocalPath;

            return dataAccess.GetStreamReader(filePath);
        }
    }
}
