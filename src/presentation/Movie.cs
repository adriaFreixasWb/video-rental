using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int GetPriceCode() =>
            _priceCode;

        public void SetPriceCode(int arg)
        {
            _priceCode=arg;
        }
    }
}
