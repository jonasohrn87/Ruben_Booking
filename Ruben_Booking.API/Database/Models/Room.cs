namespace Ruben_Booking.API.Database.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int MaxSeats { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsInService { get; set; }
        public bool HasProjector { get; set; }
        public bool HasWhiteBoard { get; set; }
    }
}
