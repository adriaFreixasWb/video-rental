namespace VideoRental.Presentation
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        public abstract double GetCharge(int daysRented);

        internal int GetFrequentRenterPoints(int daysRented)
        {
            if (GetPriceCode() == Movie.NEW_RELEASE &&
                daysRented > 1)
                return 2;

            return 1;
        }
    }
}
