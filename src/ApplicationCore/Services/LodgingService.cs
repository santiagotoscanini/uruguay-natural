using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using Exceptions;

namespace ApplicationCore.Services
{
    public class LodgingService : ILodgingService
    {
        private readonly ILodgingRepository _repository;

        private ITouristPointService _touristPointService;
        private IPriceCalculatorService _priceCalculatorService;
        private string _notFoundLodgingsMessage = "No lodgings were found that meet the conditions";

        public LodgingService(ILodgingRepository repository, ITouristPointService touristPointService,
            IPriceCalculatorService priceCalculatorService)
        {
            _repository = repository;
            _touristPointService = touristPointService;
            _priceCalculatorService = priceCalculatorService;
        }

        public Lodging Add(Lodging lodging, int touristPointId)
        {
            lodging.TouristPoint = _touristPointService.GetTouristPointById(touristPointId);

            return _repository.Add(lodging);
        }

        public void Delete(int lodgingId)
        {
            _repository.Delete(lodgingId);
        }

        public IEnumerable<Lodging> GetAll()
        {
            return _repository.GetAll();
        }

        public Lodging GetById(int lodgingId)
        {
            return _repository.GetById(lodgingId);
        }

        public Lodging Update(Lodging lodging)
        {
            return _repository.Update(lodging);
        }

        public Dictionary<Lodging, double> FilterLodgings(LodgingToFilter lodgingToFilter)
        {
            var lodgingsToReturn = _repository.FilterLodgings(lodgingToFilter);
            Dictionary<Lodging, double> lodgingWithPrices = UpdateCalculatedPrice(lodgingsToReturn, lodgingToFilter);
            return lodgingWithPrices;
        }
        
        private Dictionary<Lodging, double> UpdateCalculatedPrice(IEnumerable<Lodging> lodgings,
            LodgingToFilter lodgingToFilter)
        {
            var totalDays = (int) (lodgingToFilter.CheckOutDate - lodgingToFilter.CheckInDate).TotalDays;
            
            var lodgingsAndPrices = new Dictionary<Lodging, double>();
            foreach (var lodging in lodgings)
            {
                double calculatedPrice =
                    _priceCalculatorService.CalculatePrice(lodgingToFilter.NumberOfGuests, lodging.CostPerNight) *
                    totalDays;
                lodgingsAndPrices.Add(lodging, calculatedPrice);
            }

            return lodgingsAndPrices;
        }
        
        public IEnumerable<Lodging> GetFilteredByTouristPointAndRange(LodgingToFilter lodgingToFilter)
        {
            var lodgings = GetAll().Where(l => l.TouristPoint.Id.Equals(lodgingToFilter.TouristPointId));
            lodgings = FilterByDateRange(lodgings, lodgingToFilter);
            if (!lodgings.Any())
            {
                throw new NotFoundException(_notFoundLodgingsMessage);
            }

            ((List<Lodging>)lodgings).Sort();
            return lodgings;
        }

        private IEnumerable<Lodging> FilterByDateRange(IEnumerable<Lodging> lodgings, LodgingToFilter lodgingToFilter)
        {
            var filteredLodgings = new List<Lodging>();
            foreach (var lodging in lodgings)
            {
                var bookings = lodging.Bookings.Where(b => b.CheckOutDate >= lodgingToFilter.CheckInDate &&
                                                           b.CheckInDate <= lodgingToFilter.CheckOutDate && b.State != BookingState.EXPIRED 
                                                           && b.State != BookingState.REJECT);
                if (bookings.Any())
                {
                    filteredLodgings.Add(lodging);
                }
            }

            return filteredLodgings;
        }
    }
}
