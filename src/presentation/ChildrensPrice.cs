namespace VideoRental.Presentation
{
    public class ChildrensPrice : Price
    {
        public override int GetPriceCode() =>
            Movie.CHILDRENS;
    }
}
