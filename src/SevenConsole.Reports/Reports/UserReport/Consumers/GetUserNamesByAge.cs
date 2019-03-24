using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.Reports.UserReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenConsole.Reports.Reports.UserReport.Consumers
{
    public class GetUserNamesByAge : IDataConsumer<User>
    {
        private readonly byte _age;
        private string _result;
        private int? _maxLines;
        private int? _resultMaxLength;

        public GetUserNamesByAge(byte age)
        {
            _age = age;
            _result = string.Empty;
        }

        public void Consume(User record)
        {
            if (record.Age == _age)
            {
                if (record.Age == _age && !string.IsNullOrWhiteSpace(record.FirstName))
                {
                    if (!_resultMaxLength.HasValue)
                    {
                        _result = string.Join(", ", _result, record.FirstName.Trim());
                    }
                    else if (_resultMaxLength.HasValue && _result.Length < _resultMaxLength.Value)
                    {
                        _result = _result
                            + (string.IsNullOrWhiteSpace(_result) ? string.Empty : ", ")
                            + record.FirstName.Trim();

                        if (_result.Length >= _resultMaxLength.Value)
                        {
                            _result = $"{_result} -- (The results have been trimed to maximum {_maxLines.Value} lines)";
                        }
                    }
                }
            }
        }

        public IDataConsumer<User> SetMaxResultLines(int maxLines)
        {
            _maxLines = maxLines;

            _resultMaxLength = Console.BufferWidth * maxLines;

            return this;
        }

        public void PrintResult()
        {
            Console.WriteLine($"All the users first names who are {_age}:");

            if (_result?.Any() ?? false)
            {
                Console.WriteLine(string.Join(", ", _result));
            }
            else
            {
                Console.WriteLine("Not Found");
            }

            Console.WriteLine(string.Empty);
        }
    }
}
