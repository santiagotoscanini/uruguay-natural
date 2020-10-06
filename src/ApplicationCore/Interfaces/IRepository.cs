using Entities;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Booking> GetBookings();

        Booking AddBooking(Booking booking);
    }
}
