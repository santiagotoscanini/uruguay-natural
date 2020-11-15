using System.Collections.Generic;
using Entities;

namespace ApplicationCoreInterface.Services
{
    public interface IBookingService
    {
        Booking Add(Booking booking);
        IEnumerable<Booking> GetAll();
        Booking Get(string bookingCode);
        void UpdateState(Booking booking);
        void UpdateReview(Booking booking);
    }
}
