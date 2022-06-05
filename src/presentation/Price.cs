namespace VideoRental.Presentation
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        public virtual double GetCharge(int daysRented)
        {
            var result = 0d;
            switch (GetPriceCode())
            {
                case Movie.CHILDRENS:
                    result += 1.5d;
                    if (daysRented > 3)
                    {
                        result += (daysRented - 3) * 1.5d;
                    }
                    break;
            }

            return result;
        }
    }
}
