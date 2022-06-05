namespace VideoRental.Presentation
{
    public class Movie
    {
        public const int CHILDRENS = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private readonly string _title;
        private int _priceCode;

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
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
            _priceCode;

        public void SetPriceCode(int arg)
        {
            _priceCode=arg;
        }
    }
}
