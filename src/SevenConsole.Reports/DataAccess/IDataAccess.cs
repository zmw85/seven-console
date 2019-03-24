using System.IO;

namespace SevenConsole.Reports.DataAccess
{
    public interface IDataAccess
    {
        StreamReader GetStreamReader(string dataSource);
    }
}
