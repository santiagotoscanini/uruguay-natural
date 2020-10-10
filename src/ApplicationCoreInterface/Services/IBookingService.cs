using System.Collections.Generic;
using Entities;
using Models.BookingModels;

namespace ApplicationCoreInterface.Services
{
    public interface IBookingService
    {
        Booking Add(Booking booking);
        IEnumerable<Booking> GetAll();
        Booking Get(string bookingCode);
        void Update(BookingStateInfoModel booking);
    }
}
