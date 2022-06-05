namespace VideoRental.Presentation
{
    public class ChildrensPrice : Price
    {
        public override int GetPriceCode() =>
            Movie.CHILDRENS;

        public override double GetCharge(int daysRented)
        {
            var result = 1.5d;
            if (daysRented > 3)
            {
                result += (daysRented - 3) * 1.5d;
            }
            return result;
        }
    }
}
