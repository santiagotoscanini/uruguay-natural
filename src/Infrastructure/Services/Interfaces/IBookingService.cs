using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Infrastructure.Services.Interfaces
{
    public interface IBookingService
    {
        IEnumerable<Booking> GetAll();
        Booking Add(Booking booking);
    }
}
