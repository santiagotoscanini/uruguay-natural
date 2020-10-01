namespace ApplicationCore.Entities
{
    public enum BookingState
    {
        CREATED = 0,
        PENDING_OF_PAY = 1,
        ACCEPTED = 2,
        REJECT = 3,
        EXPIRED = 4,
    }
}