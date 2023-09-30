using Example.Source._CashRegister;
using FluentAssertions;

namespace Example.Source.Tests._CashRegister
{
    public class CashRegisterTests
    {
        [Fact]
        public void Buy_AddsMoneyToRegistersBalance_TakesMoneyFromBankAccountsBalance()
        {
            var cashRegister = new CashRegister();

            const int initialBalance = 1;
            var item = new Item { Price = initialBalance };
            var bankAccount = new BankAccount { Balance = initialBalance };

            cashRegister.Buy(item, bankAccount);

            // Don't hardcode.
            // No need two tests - both will always happen together.
            cashRegister.Balance.Should().Be(initialBalance + item.Price);
            bankAccount.Balance.Should().Be(initialBalance - item.Price);
        }
    }
}
