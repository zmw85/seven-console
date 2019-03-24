namespace SevenConsole.Reports.Consumers
{
    public interface IDataConsumer<TRecord>
    {
        void Consume(TRecord record);

        void PrintResult();
    }
}
