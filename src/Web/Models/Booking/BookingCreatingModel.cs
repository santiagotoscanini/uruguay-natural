using Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.BookingModels
{
    public class BookingCreatingModel
    {
        [Required]
        public string TouristName { get; set; }

        [Required]
        public string TouristSurname { get; set; }

        [Required]
        [EmailAddress]
        public string TouristEmail { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

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
                State = BookingState.CREATED,
                Description = "",
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate,
                NumberOfGuests = NumberOfGuests,
        };
        }
    }
}
