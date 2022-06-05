namespace VideoRental.Presentation
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented = 0)
        {
            this._movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented() =>
            _daysRented;
        public Movie GetMovie() =>
            _movie;

        public double GetCharge()
        {
            var result = 0d;
            switch (GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    result += 2d;
                    if (GetDaysRented() > 2)
                    {
                        result += (GetDaysRented() - 2) * 1.5d;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    result += GetDaysRented() * 3d;
                    break;
                case Movie.CHILDRENS:
                    result += 1.5d;
                    if (GetDaysRented() > 3)
                    {
                        result += (GetDaysRented() - 3) * 1.5d;
                    }
                    break;
            }

            return result;
        }

        internal int GetFrequentRenterPoints()
        {
            if (GetMovie().GetPriceCode() == Movie.NEW_RELEASE &&
                GetDaysRented() > 1)
                return 2;
            
            return 1;
        }
    }
}
