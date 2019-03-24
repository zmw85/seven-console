using AutoMapper;
using SevenConsole.Configuration;
using SevenConsole.Reports.Reports.UserReport.Models;

namespace SevenConsole.Mappings
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<UserReport, UserReportRequest>();
        }
    }
}
