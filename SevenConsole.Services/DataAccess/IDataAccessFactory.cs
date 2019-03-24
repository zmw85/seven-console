using SevenConsole.Reports.Reports.Models;

namespace SevenConsole.Reports.DataAccess
{
    public interface IDataAccessFactory
    {
        IDataAccess GetDataAccess(ReportRequest request);
    }
}
