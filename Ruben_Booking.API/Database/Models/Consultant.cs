namespace Ruben_Booking.API.Database.Models
{
    public class Consultant
    {
        public int Id { get; set; }
        public string? UserCredential { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public byte[]? Salt { get; set; }

    }
}
