using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
