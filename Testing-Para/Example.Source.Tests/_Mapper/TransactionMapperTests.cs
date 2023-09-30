using Example.Source._Mapper;
using FluentAssertions;
using static Example.Source.Tests.Dummy;

namespace Example.Source.Tests._Mapper
{
    public class TransactionMapperTests
    {
        [Fact]
        public void Tst()
        {
            var mapper = new TransactionMapper();
            // No need to hardcode values
            var transaction = Any<Transaction>();

            var mappedResponse = mapper.Map(transaction);

            // Many put this in arrange
            // No need to hardcode values
            var expectedResponse = new TransactionResponse
            {
                Id = transaction.Id,
                DateTime = transaction.DateTimeIssued,
                Description = transaction.Description,
                Amount = transaction.Amount
            };
            // No need to assert many properties one by one
            // Definitely no need to make a test per single property assertion
            mappedResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
}
