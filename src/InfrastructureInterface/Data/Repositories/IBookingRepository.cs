﻿using Entities;
using Models.BookingModels;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();

        Booking Add(Booking booking);

        Booking Get(string code);

        void Update(BookingStateInfoModel booking);
    }
}
