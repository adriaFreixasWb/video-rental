namespace VideoRental.Presentation
{
    public class RegularPrice : Price
    {
        public override int GetPriceCode() =>
            Movie.REGULAR;
    }
}
