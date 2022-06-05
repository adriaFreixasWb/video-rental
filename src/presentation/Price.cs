namespace VideoRental.Presentation
{
    public abstract class Price
    {
        public abstract int GetPriceCode();

        internal double GetCharge(int daysRented)
        {
            var result = 0d;
            switch (GetPriceCode())
            {
                case Movie.REGULAR:
                    result += 2d;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5d;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3d;
                    break;
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
