namespace VideoRental.Presentation
{
    public class Customer
    {
        private readonly string _name;

        private readonly List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental arg)=>
            _rentals.Add(arg);

        public string GetName() =>
            _name;

        public string Statement()
        {
            var totalAlmount = 0d;
            var frequentRenterPoints = 0;
            var result = $"Rental record for {GetName()} \n";
            foreach (var rental in _rentals)
            {
                double thisAmount = AmountFor(rental);
                //add frequent renter points
                frequentRenterPoints++;
                //add bonus for a 2 day rental
                if (rental.GetMovie().GetPriceCode() == Movie.NEW_RELEASE &&
                    rental.GetDaysRented() > 1)
                    frequentRenterPoints++;

                //show figures for this rental
                result += $"\t {rental.GetMovie().GetTitle()}\t{thisAmount}\n";
                totalAlmount += thisAmount;

            }
            //add footer
            result += $"amount owed {totalAlmount}\n";
            result += $"you earned {frequentRenterPoints} " +
                "frequent renter points\n";
            
            return result;
        }

        private double AmountFor(Rental rental)
        {
            var thisAmount = 0d;
            switch (rental.GetMovie().GetPriceCode())
            {
                case Movie.REGULAR:
                    thisAmount += 2d;
                    if (rental.GetDaysRented() > 2)
                    {
                        thisAmount += (rental.GetDaysRented() - 2) * 1.5d;
                    }
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.GetDaysRented() * 3d;
                    break;
                case Movie.CHILDRENS:
                    thisAmount += 1.5d;
                    if (rental.GetDaysRented() > 3)
                    {
                        thisAmount += (rental.GetDaysRented() - 3) * 1.5d;
                    }
                    break;
            }

            return thisAmount;
        }
    }
}
