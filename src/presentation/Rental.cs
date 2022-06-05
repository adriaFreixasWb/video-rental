namespace VideoRental.Presentation
{
    public class Rental
    {
        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented = 0)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public int GetDaysRented() =>
            _daysRented;
        public Movie GetMovie() =>
            _movie;

        public double GetCharge() => 
            _movie.GetCharge(GetDaysRented());

        internal int GetFrequentRenterPoints()
        {
            if (GetMovie().GetPriceCode() == Movie.NEW_RELEASE &&
                GetDaysRented() > 1)
                return 2;
            
            return 1;
        }
    }
}
