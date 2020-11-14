namespace Entities
{
    public class NumberOfGuests
    {
        public int NumberOfChildren { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfBabies { get; set; }
        public int NumberOfRetired { get; set; }

        public int GetTotalNumberOfGuests()
        {
            return NumberOfChildren + NumberOfAdults + NumberOfBabies + NumberOfRetired;
        }
    }
}