namespace Example.Source._CashRegister
{
    public class CashRegister
    {
        public decimal Balance { get; private set; }
        
        public void Buy(Item item, BankAccount bankAccount)
        {
            Balance += item.Price;
            bankAccount.Balance -= item.Price;
        }
    }
}
