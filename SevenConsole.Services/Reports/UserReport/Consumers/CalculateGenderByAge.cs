using SevenConsole.Reports.Consumers;
using SevenConsole.Reports.Reports.UserReport.Models;
using SevenConsole.Reports.Reports.UserReport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenConsole.Reports.Reports.UserReport.Consumers
{
    public class CalculateGenderByAge : IDataConsumer<User>
    {
        private readonly string[] MALE_ACRONYM = new string[] { "M", "T" };
        private readonly string[] FEMALE_ACRONYM = new string[] { "F", "Y" };

        private List<GenderCount> _result;
        private Dictionary<byte, GenderCount> _genderCountDictionary;
        private bool _ordered;

        public CalculateGenderByAge()
        {
            _result = new List<GenderCount>();
            _genderCountDictionary = new Dictionary<byte, GenderCount>();
        }

        public static List<GenderCount> Ages { get; set; }

        public void Consume(User record)
        {
            _genderCountDictionary.TryGetValue(record.Age, out GenderCount item);

            if (item == null)
            {
                item = new GenderCount(record.Age);
                _genderCountDictionary.Add(record.Age, item);
                _result.Add(item);
            }

            if (string.IsNullOrWhiteSpace(record.Gender))
            {
                return;
            }

            if (MALE_ACRONYM.Contains(record?.Gender.ToUpper()))
            {
                item.MaleCount++;
            }
            else if (FEMALE_ACRONYM.Contains(record?.Gender.ToUpper()))
            {
                item.FemaleCount++;
            }
        }

        public List<GenderCount> GetResult()
        {
            if (!_ordered && (_result?.Any() ?? false))
            {
                _result.OrderBy(c => c.Age);
                _ordered = true;
            }

            return _result;
        }

        public void PrintResult()
        {
            var result = GetResult();

            Console.WriteLine($"The number of genders per age:");

            if (result == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"Age: {item.Age} Female: {item.FemaleCount} Male: {item.MaleCount}");
                }
            }

            Console.WriteLine(string.Empty);
        }
    }
}
