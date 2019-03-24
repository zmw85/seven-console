using SevenConsole.Reports.Enums;
using SevenConsole.Reports.Reports.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenConsole.Reports.DataAccess
{
    public class DataAccessFactory : IDataAccessFactory
    {
        private readonly IDataAccess _localDataAccess;

        public DataAccessFactory(IDataAccess localDataAccess)
        {
            _localDataAccess = localDataAccess;
        }

        public IDataAccess GetDataAccess(ReportRequest request)
        {
            switch (ResolveDataSource(request.SourceUri))
            {
                case DataSources.LocalFile:
                    return _localDataAccess;
                default:
                    return null;
            }
        }

        private DataSources ResolveDataSource(string uri)
        {
            return new Uri(uri).IsFile ? DataSources.LocalFile : DataSources.Http;
        }
    }
}
