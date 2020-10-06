using System.Collections.Generic;
using Entities;

namespace ApplicationCore.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Booking Add(Booking booking);
    }
}
