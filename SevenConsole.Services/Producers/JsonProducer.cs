using Newtonsoft.Json;
using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.DataAccess;
using SevenConsole.Reports.Reports.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SevenConsole.Reports.Producers
{
    public class JsonProducer<TRecord> : Producer<TRecord>
    {
        public JsonProducer(IDataAccessFactory dataAccessFactory) : base(dataAccessFactory) {}

        public override async Task<bool> ProcessData(ReportRequest request)
        {
            if (Consumers.Count == 0)
            {
                Console.WriteLine("Required at least one consumer for data to be processed.");
                return false;
            }

            if (!IsFormatSupported(request.Format))
            {
                Console.WriteLine("The data format is not supported.");
                return false;
            }

            StreamReader streamReader = null;

            try
            {
                streamReader = GetStream(request);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            using (JsonReader reader = new JsonTextReader(streamReader))
            {
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    while (await reader.ReadAsync())
                    {
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            var element = serializer.Deserialize<TRecord>(reader);

                            foreach (var consumer in Consumers)
                            {
                                consumer.Consume(element);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error occurred while reading the file ('{request}'):");
                    Console.WriteLine(e.Message);
                }
            }

            return true;
        }
    }
}
