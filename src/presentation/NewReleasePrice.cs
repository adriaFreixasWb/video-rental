namespace VideoRental.Presentation
{
    public class NewReleasePrice : Price
    {
        public override int GetPriceCode() =>
            Movie.NEW_RELEASE;

        public override double GetCharge(int daysRented) =>
            daysRented * 3d;

        public override int GetFrequentRenterPoints(int daysRented) =>
            daysRented > 1
            ? 2
            :base.GetFrequentRenterPoints(daysRented);
    }
}
