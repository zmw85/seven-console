using Newtonsoft.Json;

namespace SevenConsole.Reports.Reports.UserReport.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "first")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last")]
        public string LastName { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                return $"{FirstName?.Trim()} {LastName?.Trim()}";
            }
        }

        [JsonProperty(PropertyName = "age")]
        public byte Age { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"id: {Id}, first: {FirstName}, last: {LastName}, age: {Age}, gender: {Gender}";
        }
    }
}
