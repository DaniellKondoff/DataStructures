namespace DDDInPractice.Logic
{
    public class Money : ValueObject<Money>
    {
        public static readonly Money None = new Money(0, 0);
        public static readonly Money Cent = new Money(1, 0);
        public static readonly Money TenCent = new Money(0, 1);

        public int OneCentCount { get; }
        public int TenCentCount { get; }

        public decimal Amount => this.OneCentCount * 0.01m + this.TenCentCount * 0.10m;

        public Money(int oneCentCount, int tenCentCount)
        {
            this.OneCentCount = oneCentCount;
            this.TenCentCount = tenCentCount;
        }

        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount + money2.OneCentCount,
                money1.TenCentCount + money2.TenCentCount
                );

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount - money2.OneCentCount,
                money1.TenCentCount - money2.TenCentCount
                );

            return sum;
        }


        protected override bool EqualsCore(Money other)
        {
            return OneCentCount == other.OneCentCount
                && TenCentCount == other.TenCentCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                return hashCode;
            }
        }
    }
}
