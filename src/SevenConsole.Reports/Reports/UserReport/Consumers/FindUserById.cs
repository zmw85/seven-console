using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.Reports.UserReport.Models;
using System;

namespace SevenConsole.Reports.Reports.UserReport.Consumers
{
    public class FindUserById : IDataConsumer<User>
    {
        private readonly int _id;
        private User _result;

        public FindUserById(int id)
        {
            _id = id;
        }

        public void Consume(User record)
        {
            if (_result == null && record.Id == _id)
            {
                _result = record;
            }
        }

        public void PrintResult()
        {
            Console.WriteLine($"User's full name for id {_id}:");

            if (_result == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine(_result.FullName);
            }

            Console.WriteLine(string.Empty);
        }
    }
}
