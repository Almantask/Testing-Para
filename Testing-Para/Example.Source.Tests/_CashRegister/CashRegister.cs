using Example.Source._CashRegister;
using FluentAssertions;
using static Example.Source.Tests.Dummy;

namespace Example.Source.Tests._CashRegister
{
    public class CashRegisterTests
    {
        [Fact]
        public void Buy_AddsMoneyToRegistersBalance_TakesMoneyFromBankAccountsBalance()
        {
            // Arrange
            var item = Any<Item>();
            
            var initialBalance = Any<int>();
            var bankAccount = new BankAccount { Balance = initialBalance };
            
            var cashRegister = new CashRegister(initialBalance);

            // Act
            cashRegister.Buy(item, bankAccount);

            // Assert
            // Don't hardcode.
            // No need two tests - both will always happen together.
            cashRegister.Balance.Should().Be(initialBalance + item.Price);
            bankAccount.Balance.Should().Be(initialBalance - item.Price);
        }
    }
}
