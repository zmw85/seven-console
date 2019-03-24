using Xunit;
using FluentAssertions;
using SevenConsole.Reports.Reports.UserReport.Models;
using SevenConsole.Reports.Reports.UserReport.Consumers;
using SevenConsole.Reports.Reports.UserReport.ViewModels;

namespace SevenConsole.Reports.Test.Reports.Consumers
{
    public class CalculateGenderByAgeTest
    {
        [Fact]
        public void Consume_SingleMale_ExpectCorrecttResult()
        {
            // arrange
            var consumer = new CalculateGenderByAge();
            var user = new User
            {
                Id = 1,
                Age = 20,
                FirstName = "Winston",
                LastName = "Wen",
                Gender = "M"
            };

            // action
            consumer.Consume(user);
            var results = consumer.GetResult();

            // assert
            results.Should()
                .NotBeNullOrEmpty().And
                .ContainSingle().And
                .ContainEquivalentOf(new GenderCount(20)
                {
                    MaleCount = 1,
                    FemaleCount = 0
                });
        }

        [Fact]
        public void Consume_SingleFemale_ExpectCorrecttResult()
        {
            // arrange
            var consumer = new CalculateGenderByAge();
            var user = new User
            {
                Id = 1,
                Age = 20,
                FirstName = "Winston",
                LastName = "Wen",
                Gender = "F"
            };

            // action
            consumer.Consume(user);
            var results = consumer.GetResult();

            // assert
            results.Should()
                .NotBeNullOrEmpty().And
                .ContainSingle().And
                .ContainEquivalentOf(new GenderCount(20)
                {
                    MaleCount = 0,
                    FemaleCount = 1
                });
        }

        [Fact]
        public void Consume_MultipleMix_ExpectCorrecttResult()
        {
            // arrange
            var consumer = new CalculateGenderByAge();
            var user1 = new User
            {
                Id = 1,
                Age = 20,
                FirstName = "Winston",
                LastName = "Wen",
                Gender = "M"
            };
            var user2 = new User
            {
                Id = 2,
                Age = 20,
                FirstName = "Lucy",
                LastName = "Gray",
                Gender = "F"
            };
            var user3 = new User
            {
                Id = 3,
                Age = 70,
                FirstName = "Donald",
                LastName = "Trump",
                Gender = "T"
            };

            // action
            consumer.Consume(user1);
            consumer.Consume(user2);
            consumer.Consume(user3);
            var results = consumer.GetResult();

            // assert
            results.Should()
                .NotBeNullOrEmpty().And
                .HaveCount(2).And
                .ContainEquivalentOf(new GenderCount(20)
                {
                    MaleCount = 1,
                    FemaleCount = 1
                }).And
                .ContainEquivalentOf(new GenderCount(70)
                {
                    MaleCount = 1,
                    FemaleCount = 0
                });
        }
    }
}
