namespace TddBank.Tests
{

    /// <summary>
    /// Bankkonto
    ///- Kontostand abfragen
    ///- Betrag einzahlen(nicht Negativ)
    ///- Betrag abheben(nicht Negativ)
    ///	- Darf nicht unter 0 fallen
    ///- Neues Konto hat 0 als Kontostand
    /// </summary>
    public class BankAccountTests
    {
        [Fact]
        public void New_account_should_have_0_as_Balance()
        {
            var ba = new BankAccount();

            Assert.Equal(0m, ba.Balance);
        }

        [Fact]
        public void Deposit_should_add_to_Balance()
        {
            var ba = new BankAccount();

            ba.Deposit(6m);
            ba.Deposit(7m);

            Assert.Equal(13m, ba.Balance);
        }

        [Fact]
        public void Deposit_a_negative_value_should_throw_ArgumentExecption()
        {
            var ba = new BankAccount();

            Assert.Throws<ArgumentException>(() => ba.Deposit(-1m));
        }

        [Fact]
        public void Withdraw_should_substract_from_Balance()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            ba.Withdraw(4m);

            Assert.Equal(8m, ba.Balance);
        }

        [Fact]
        public void Withdraw_a_negative_value_should_throw_ArgumentExecption()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<ArgumentException>(() => ba.Withdraw(-1m));
        }

        [Fact]
        public void Withdraw_more_than_balance_should_throw_InvalidOperationExecption()
        {
            var ba = new BankAccount();
            ba.Deposit(12m);

            Assert.Throws<InvalidOperationException>(() => ba.Withdraw(13m));
        }

    }
}