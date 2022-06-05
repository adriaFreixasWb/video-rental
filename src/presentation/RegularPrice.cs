namespace VideoRental.Presentation
{
    public class RegularPrice : Price
    {
        public override int GetPriceCode() =>
            Movie.REGULAR;

        public override double GetCharge(int daysRented)
        {
            var result = 2d;
            if (daysRented > 2)
            {
                result += (daysRented - 2) * 1.5d;
            }
            return result;
        }
    }
}
