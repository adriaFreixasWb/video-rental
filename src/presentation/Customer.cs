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
            var result = $"Rental record for {GetName()} \n";
            foreach (var rental in _rentals)
            {
                //show figures for this rental
                result += $"\t {rental.GetMovie().GetTitle()}\t{rental.GetCharge()}\n";

            }
            //add footer
            result += $"amount owed {GetTotalCharge()}\n";
            result += $"you earned {GetTotalFrequentRenterPoints()} " +
                "frequent renter points\n";
            
            return result;
        }

        public string HtmlStatement()
        {
            var result = $"<H1>Rental record for <EM>{GetName()}</EM></H1><P>\n";
            foreach (var rental in _rentals)
            {
                //show figures for this rental
                result += $"{rental.GetMovie().GetTitle()}: {rental.GetCharge()} <BR>\n";

            }
            //add footer
            result += $"<P>You owe <EM>{GetTotalCharge()}</EM></P>\n";
            result += $"On this rental you earned <EM>{GetTotalFrequentRenterPoints()}</EM> " +
                "frequent renter points\n";

            return result;
        }

        private int GetTotalFrequentRenterPoints()
        {
            int result = 0;
            foreach (var rental in _rentals)
            {
                result += rental.GetFrequentRenterPoints();
            }
            return result;
        }

        private double GetTotalCharge()
        {
            double result = 0d;
            foreach (var rental in _rentals)
            {
                result += rental.GetCharge();
            }
            return result;
        }
    }
}
