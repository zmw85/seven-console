using SevenConsole.Reports.Reports.UserReport.Models;
using System.Threading.Tasks;

namespace SevenConsole.Reports.Reports
{
    public interface IReportGenerator
    {
        Task GenerateReport(UserReportRequest request);
    }
}
