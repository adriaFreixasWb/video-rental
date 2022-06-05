namespace VideoRental.Presentation
{
    public class NewReleasePrice : Price
    {
        public override int GetPriceCode() =>
            Movie.NEW_RELEASE;

        public override double GetCharge(int daysRented) =>
            daysRented * 3d;
    }
}
