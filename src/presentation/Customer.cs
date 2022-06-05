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
                frequentRenterPoints = rental.GetFrequentRenterPoints();

                //show figures for this rental
                result += $"\t {rental.GetMovie().GetTitle()}\t{rental.GetCharge()}\n";
                totalAlmount += rental.GetCharge();

            }
            //add footer
            result += $"amount owed {totalAlmount}\n";
            result += $"you earned {frequentRenterPoints} " +
                "frequent renter points\n";
            
            return result;
        }

    }
}
