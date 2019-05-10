namespace DDDInPractice.Logic
{
    public sealed class SnackMachine : Entity
    {
        public Money MoneyInSide { get; private set; }
        public Money MoneyInTransaction { get; private set; }

        public SnackMachine()
        {
            MoneyInSide = Money.None;
            MoneyInTransaction = Money.None;
        }

        public void InsertMoney(Money money)
        {
            this.MoneyInTransaction += money;
        }

        public void ReturnMoney()
        {
            this.MoneyInTransaction = Money.None;
        }

        public void BuiSnack()
        {
            MoneyInSide += MoneyInTransaction;

            this.MoneyInTransaction = Money.None;
        }
    }
}
