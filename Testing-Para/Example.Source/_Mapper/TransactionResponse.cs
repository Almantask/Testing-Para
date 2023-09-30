namespace Example.Source._Mapper
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
