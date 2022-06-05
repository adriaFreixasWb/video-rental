using Xunit;
using VideoRental.Presentation;
using System.Collections.Generic;

namespace VideoRental.Test;

public class CustomerShould
{
    private readonly Customer CUSTOMER = new Customer("John");
    private readonly Dictionary<string, Rental> RENTALS_DATA = new Dictionary<string, Rental>();
    private readonly Movie CHILDRENS_MOVIE = new Movie("Dumbo", 2);
    private readonly Movie REGULAR_MOVIE = new Movie("Star wars", 0);
    private readonly Movie NEW_RELEASE_MOVIE = new Movie("Matrix eternal", 1); 
    public CustomerShould()
    {
        RENTALS_DATA.Add("ONE_DAY_CHILDRENS", new Rental(CHILDRENS_MOVIE, 1));
        RENTALS_DATA.Add("ONE_WEEK_CHILDRENS", new Rental(CHILDRENS_MOVIE, 7));
        RENTALS_DATA.Add("ONE_DAY_REGULAR", new Rental(REGULAR_MOVIE, 1));
        RENTALS_DATA.Add("ONE_WEEK_REGULAR", new Rental(REGULAR_MOVIE, 7));
        RENTALS_DATA.Add("ONE_DAY_NEW_RELEASE", new Rental(NEW_RELEASE_MOVIE, 1));
        RENTALS_DATA.Add("ONE_WEEK_NEW_RELEASE", new Rental(NEW_RELEASE_MOVIE, 7));

    }
    [Fact]
    public void Have_No_Points()
    {
        var exptected = "Rental record for John \namount owed 0\nyou earned 0 frequent renter points\n";
        var statment = CUSTOMER.Statement();
        Assert.Equal(exptected, statment);
    }

    [Theory]
    [InlineData("ONE_DAY_REGULAR", "Rental record for John \n\t Star wars\t2\namount owed 2\nyou earned 1 frequent renter points\n")]
    [InlineData("ONE_DAY_CHILDRENS", "Rental record for John \n\t Dumbo\t1.5\namount owed 1.5\nyou earned 1 frequent renter points\n")]
    [InlineData("ONE_WEEK_REGULAR", "Rental record for John \n\t Star wars\t9.5\namount owed 9.5\nyou earned 1 frequent renter points\n")]
    [InlineData("ONE_WEEK_CHILDRENS", "Rental record for John \n\t Dumbo\t7.5\namount owed 7.5\nyou earned 1 frequent renter points\n")]
    [InlineData("ONE_DAY_NEW_RELEASE", "Rental record for John \n\t Matrix eternal\t3\namount owed 3\nyou earned 1 frequent renter points\n")]
    [InlineData("ONE_WEEK_NEW_RELEASE", "Rental record for John \n\t Matrix eternal\t21\namount owed 21\nyou earned 2 frequent renter points\n")]
    public void Have_Rental_Points(string priceCode, string expected)
    {
        CUSTOMER.AddRental(RENTALS_DATA[priceCode]);
        var statment = CUSTOMER.Statement();
        Assert.Equal(expected, statment);
    }

}