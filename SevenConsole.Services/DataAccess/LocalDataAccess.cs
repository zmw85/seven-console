using System.IO;
using System;

namespace SevenConsole.Reports.DataAccess
{
    public class LocalDataAccess : IDataAccess
    {
        public StreamReader GetStreamReader(string dataSource)
        {
            try
            {
                var fileStream = File.Open(dataSource, FileMode.Open);
                return new StreamReader(fileStream);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception occurred while open the file ('{dataSource}'):");
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
