namespace Ruben_Booking.API.Database.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? UserCredential { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
    }
}
