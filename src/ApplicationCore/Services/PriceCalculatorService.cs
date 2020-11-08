using System.Collections.Generic;
using ApplicationCoreInterface.Services;
using Entities;

namespace ApplicationCore.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        private readonly IGuestService _guestService;

        public PriceCalculatorService(IGuestService guestService)
        {
            _guestService = guestService;
        }

        public double CalculatePrice(NumberOfGuests numberOfGuests, double price)
        {
            double calculatedPrice = 0.0;
            Dictionary<Guest, int> guestsMap = MappingGuests(numberOfGuests);
            foreach (var guest in guestsMap)
            {
                var percentagePayedByGuest = guest.Key.Percentage;
                var numberOfGuestOfType = guest.Value;
                calculatedPrice += (price * percentagePayedByGuest / 100) * numberOfGuestOfType;
            }
            return calculatedPrice;
        }
        
        private Dictionary<Guest, int> MappingGuests(NumberOfGuests numberOfGuests)
        {
            var guestsMap = new Dictionary<Guest, int>();
            var guests = _guestService.GetAll();
            foreach (var guest in guests)
            {
                if (guest.Name.Equals("Adult"))
                {
                    guestsMap.Add(guest, numberOfGuests.NumberOfAdults);
                }
                else if (guest.Name.Equals("Child"))
                {   
                    guestsMap.Add(guest, numberOfGuests.NumberOfChildren);
                }
                else if (guest.Name.Equals("Baby"))
                {
                    guestsMap.Add(guest, numberOfGuests.NumberOfBabies);
                }
            }
            return guestsMap;
        }
    }
}