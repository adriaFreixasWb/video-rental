namespace VideoRental.Presentation
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private readonly string _title;
        private Price _price;

        public Movie(string title, int priceCode)
        {
            _title = title;
            SetPriceCode(priceCode);
        }

        public string GetTitle() =>
            _title;

        public double GetCharge(int daysRented)
        {
            var result = 0d;
            switch (GetPriceCode())
            {
                case REGULAR:
                    result += 2d;
                    if (daysRented > 2)
                    {
                        result += (daysRented - 2) * 1.5d;
                    }
                    break;
                case NEW_RELEASE:
                    result += daysRented * 3d;
                    break;
                case CHILDRENS:
                    result += 1.5d;
                    if (daysRented > 3)
                    {
                        result += (daysRented - 3) * 1.5d;
                    }
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if (GetPriceCode() == NEW_RELEASE &&
                daysRented > 1)
                return 2;

            return 1;
        }

        public int GetPriceCode() =>
            _price.GetPriceCode();

        public void SetPriceCode(int arg)
        {
            switch (arg)
            {
                case REGULAR:
                    _price = new RegularPrice();
                    break;
                case CHILDRENS:
                    _price = new ChildrensPrice();
                    break;
                case NEW_RELEASE:
                    _price = new NewReleasePrice();
                    break;
                default:
                    throw new ArgumentException("Incorrect price code");
            }
        }
    }
}
