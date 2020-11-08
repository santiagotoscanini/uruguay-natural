using System.Collections.Generic;
using Entities;

namespace ApplicationCoreInterface.Services
{
    public interface IPriceCalculatorService
    {
        double CalculatePrice(NumberOfGuests numberOfGuest, double price);
    }
}