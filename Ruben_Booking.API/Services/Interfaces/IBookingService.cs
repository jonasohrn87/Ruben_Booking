using Ruben_Booking.API.Database.Models;

namespace Ruben_Booking.API.Services.Interfaces

{
    public interface IBookingService
    {
        Task<IResult> GetAllBookings();
        Task<IResult> GetBookingById(int id);
        Task<IResult> CreateBooking(Booking booking);
        Task<IResult> DeleteBookingById(int id);
    }
}
