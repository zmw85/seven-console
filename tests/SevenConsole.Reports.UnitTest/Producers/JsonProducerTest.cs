using Xunit;
using FluentAssertions;
using SevenConsole.Reports.Reports.UserReport.Consumers;
using SevenConsole.Reports.Producers;
using SevenConsole.Reports.Reports.UserReport.Models;
using Moq;
using SevenConsole.Reports.DataAccess;
using SevenConsole.Reports.Consumers;
using System.Collections.Generic;
using SevenConsole.Reports.Enums;
using System.Reflection;
using System;
using System.Linq;
using SevenConsole.Reports.Reports.Models;

namespace SevenConsole.Reports.Test.Producers
{
    public class JsonProducerTest
    {
        Mock<IDataAccessFactory> _dataAccessFactory;
        JsonProducer<User> _jsonProducer;

        public JsonProducerTest()
        {
            _dataAccessFactory = new Mock<IDataAccessFactory>();
            _jsonProducer = new JsonProducer<User>(_dataAccessFactory.Object);
        }

        [Fact]
        public void AddConsumer_AddSingle_ShouldSuccess()
        {
            // arrange
            var consumer = new FindUserById(40);

            // act
            _jsonProducer.AddConsumer(consumer);

            // assert
            _jsonProducer.Consumers
                .Should().NotBeNullOrEmpty().And
                .HaveCount(1).And
                .HaveElementAt(0, consumer);
        }

        [Fact]
        public void AddConsumer_AddMultiple_ShouldSuccess()
        {
            // arrange
            var consumer1 = new FindUserById(1);
            var consumer2 = new GetUserNamesByAge(2);
            var consumers = new List<IDataConsumer<User>>()
            {
                consumer1,
                consumer2
            };

            // act
            _jsonProducer.AddConsumer(consumers);

            // assert
            _jsonProducer.Consumers
                .Should().NotBeNullOrEmpty().And
                .HaveCount(2).And
                .Contain(consumers);
        }

        [Theory]
        [InlineData(DataFormats.JSON, true)]
        [InlineData(DataFormats.XML, false)]
        [InlineData(DataFormats.CSV, false)]
        public void IsFormatSupported_OnlySupportJson(DataFormats format, bool expected)
        {
            // arrange
            Type type = typeof(JsonProducer<User>);

            MethodInfo method_IsFormatSupported = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.Name == "IsFormatSupported")
                .First();

            // action
            var result = (bool)method_IsFormatSupported.Invoke(_jsonProducer, new object[] { format });

            //assert
            Assert.Equal(expected, result);
        }
    }
}
