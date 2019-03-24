using SevenConsole.Reports.Enums;

namespace SevenConsole.Reports.Reports.Models
{
    public class ReportRequest
    {
        public string SourceUri { get; set; }

        public DataFormats Format { get; set; }
    }
}
