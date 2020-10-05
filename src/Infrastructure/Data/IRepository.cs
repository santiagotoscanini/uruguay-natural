using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public interface IRepository
    {
        IEnumerable<Booking> GetBookings();

        Booking AddBooking(Booking booking);
    }
}
