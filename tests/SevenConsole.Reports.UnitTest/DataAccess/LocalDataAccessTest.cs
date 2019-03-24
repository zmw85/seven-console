using SevenConsole.Reports.DataAccess;
using Xunit;
using FluentAssertions;
using System.IO;
using System;
using System.Reflection;

namespace SevenConsole.Reports.Test.DataAccess
{
    public class LocalDataAccessTest
    {
        [Fact]
        public void GetStreamReader_OpenExistingFile_ReturnStreamReader()
        {
            // act
            var streamReader = new LocalDataAccess().GetStreamReader("DataAccess/file_1.json");

            // assert
            streamReader
                .Should().NotBeNull().And
                .BeOfType(typeof(StreamReader));
        }
    }
}
