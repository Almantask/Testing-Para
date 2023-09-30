namespace Example.Source._Mapper
{
    public class TransactionMapper
    {
        public TransactionResponse Map(Transaction transaction) => new TransactionResponse
        {
            Id = transaction.Id,
            DateTime = transaction.DateTimeIssued,
            Description = transaction.Description,
            Amount = transaction.Amount
        };
    }
}
