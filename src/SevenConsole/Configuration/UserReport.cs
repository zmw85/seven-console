using SevenConsole.Reports.Enums;

namespace SevenConsole.Configuration
{
    public class UserReport
    {
        public string SourceUri { get; set; }

        public DataFormats Format { get; set; }

        public int UserId { get; set; }

        public byte UserAge { get; set; }

        public int ReportMaxLines { get; set; }
    }
}
