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
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfAdults { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfChildren { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfBabies { get; set; }


        [Range(0, int.MaxValue, ErrorMessage = "The number of guests cannot be less than zero.")]
        public int NumberOfRetired { get; set; }

        [Required] public int LodgingId { get; set; }

        public Booking ToEntity()
        {
            var numberOfGuests = new NumberOfGuests
            {
                NumberOfAdults = this.NumberOfAdults,
                NumberOfChildren = this.NumberOfChildren,
                NumberOfBabies = this.NumberOfBabies,
                NumberOfRetired = this.NumberOfRetired
            };

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
                Lodging = new Lodging {Id = LodgingId},
                NumberOfGuests = numberOfGuests,
                TotalNumberOfGuests = numberOfGuests.GetTotalNumberOfGuests()
            };
        }
    }
}