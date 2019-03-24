using SevenConsole.Reports.Reports.Models;

namespace SevenConsole.Reports.Reports.UserReport.Models
{
    public class UserReportRequest : ReportRequest
    {
        public int UserId { get; set; }

        public byte UserAge { get; set; }

        public int? ReportMaxLines { get; set; }
    }
}
