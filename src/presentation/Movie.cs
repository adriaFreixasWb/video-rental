﻿namespace VideoRental.Presentation
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

        public double GetCharge(int daysRented) =>
            _price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented) => 
            _price.GetFrequentRenterPoints(daysRented);

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
