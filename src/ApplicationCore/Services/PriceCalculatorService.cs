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
            var calculatedPrice = 0.0;
            IDictionary<Guest, int> guestsMap = MappingGuests(numberOfGuests);
            foreach (var guest in guestsMap)
            {
                var percentagePayedByGuest = guest.Key.Percentage;
                var numberOfGuestOfType = guest.Value;
                if (guest.Key.Name.Equals("Retired"))
                {
                    var numberOfRetiredWithDiscount = numberOfGuestOfType / 2;
                    calculatedPrice += price * percentagePayedByGuest / 100 * numberOfRetiredWithDiscount;

                    var numberOfRetiredWithoutDiscount = numberOfGuestOfType % 2;
                    calculatedPrice += price * (numberOfRetiredWithDiscount + numberOfRetiredWithoutDiscount);
                }
                else
                {
                    calculatedPrice += price * percentagePayedByGuest / 100 * numberOfGuestOfType;
                }
            }

            return calculatedPrice;
        }

        private IDictionary<Guest, int> MappingGuests(NumberOfGuests numberOfGuests)
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
                else if (guest.Name.Equals("Retired"))
                {
                    guestsMap.Add(guest, numberOfGuests.NumberOfRetired);
                }
            }

            return guestsMap;
        }
    }
}