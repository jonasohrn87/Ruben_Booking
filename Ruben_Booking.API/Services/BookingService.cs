using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.ErrorHandling;
using Ruben_Booking.API.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Ruben_Booking.API.Services
{
    public class BookingService : IBookingService
    {
        private readonly RubenContext _context;
        private readonly ErrorHandler _errorHandler;
        public BookingService(RubenContext context, ErrorHandler errorHandler)
        {
            _context = context;
            _errorHandler = errorHandler;
        }

        public Task<IResult> CreateBooking(Booking newBooking)
        {
            return _errorHandler.Handle(async () =>
            {
                var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == newBooking.RoomId);
                if (room == null)
                {
                    throw new ArgumentException($"Room with id {newBooking.RoomId} does not exist.");
                }

                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == newBooking.PersonId);
                if (employee == null)
                {
                    throw new ArgumentException($"Employee with id {newBooking.PersonId} does not exist.");
                }

                var bookingAlreadyExists =
                    await _context.Bookings.FirstOrDefaultAsync(
                        b => b.RoomId == newBooking.RoomId && b.DateFrom == newBooking.DateFrom);
                if (bookingAlreadyExists != null)
                {
                    throw new ArgumentException("A booking for this room and date already exists.");
                }

                var booking = await _context.AddAsync(newBooking);
                await _context.SaveChangesAsync();
                return Results.Created($"/api/booking/create/{booking.Entity.Id}", booking);
            });
        }
        public async Task<IResult> DeleteBookingById(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

            if (booking != null)
            {
                _context.Remove(booking);
                await _context.SaveChangesAsync();
                return Results.Ok(booking);
            }
            return Results.NotFound($"The booking with id {id} was not found");
        }

        public async Task<IResult> GetAllBookings()
        {
            var bookings = await _context.Bookings.ToListAsync();

            return bookings == null
                ? Results.NotFound("No bookings were found.")
                : Results.Ok(bookings);
        }

        public async Task<IResult> GetBookingById(int id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            return booking == null
                ? Results.NotFound($"Booking id {id} not found.")
                : Results.Ok(booking);
        }
    }
}
