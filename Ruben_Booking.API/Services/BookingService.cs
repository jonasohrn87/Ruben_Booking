using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Services.Interfaces;
using Ruben_Booking.API.Database.Models;

namespace Ruben_Booking.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly RubenContext _context;
        public BookingService(RubenContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetAllBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();
            return bookings == null
                ? Results.NotFound("No bookings found")
                : Results.Ok(bookings);
        }
        public async Task<IResult> GetBookingById(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking == null
                ? Results.NotFound($"Booking id {id} not found.")
                : Results.Ok(booking);
        }
        public async Task<IResult> CreateBooking(Booking booking)
        {
            var room = await _context.Rooms.FindAsync(booking.RoomId);
            if (room == null)
                return Results.NotFound("No room found");

            if (!room.IsInService)
                return Results.BadRequest("Room is not in fuction");

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            return Results.Created($"/api/bookings/{booking.Id}", booking);
        }
    }
}
