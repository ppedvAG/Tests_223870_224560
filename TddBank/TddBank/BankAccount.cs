namespace TddBank
{

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Negative values can not be deposited");

            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException("Negative values can not be deposited");
            if (value > Balance)
                throw new InvalidOperationException("More than Balance can not be withdrawn");

            Balance -= value;
        }
    }
}