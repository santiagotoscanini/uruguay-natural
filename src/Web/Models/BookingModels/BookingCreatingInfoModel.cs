﻿using Entities;
using System;

namespace Web.Models.BookingModels
{
    public class BookingCreatingInfoModel
    {
        public string TouristName { get; set; }
        public string TouristSurname { get; set; }
        public string TouristEmail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        private readonly string DefoultDescription = "";

        public Booking ToEntity()
        {
            return new Booking()
            {
                Tourist = new Tourist
                {
                    Name = TouristName,
                    Surname = TouristSurname,
                    Email = TouristEmail,
                },
                Code = Guid.NewGuid().ToString(),
                State = BookingState.CREATED,
                Description = DefoultDescription,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate,
                NumberOfGuests = NumberOfGuests,
        };
        }
    }
}
