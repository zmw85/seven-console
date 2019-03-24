namespace SevenConsole.Reports.Reports.UserReport.ViewModels
{
    public class GenderCount
    {
        public GenderCount(byte age)
        {
            Age = age;
        }

        public byte Age { get; set; }

        public int MaleCount { get; set; }

        public int FemaleCount { get; set; }
    }
}
