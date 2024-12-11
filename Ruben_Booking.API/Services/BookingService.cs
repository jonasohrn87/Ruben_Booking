using Microsoft.AspNetCore.Mvc;
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

        public async Task<IResult> CreateBooking(Booking newBooking)
        {
                var room = await _context.Rooms.FindAsync(newBooking.RoomId);
                if (room == null)
                {
                    return Results.NotFound($"Room with id {newBooking.RoomId} does not exist.");
                }

                var employee = await _context.Employees.FindAsync(newBooking.RoomId);
                if (employee == null)
                {
                    return Results.NotFound($"Employee with id {newBooking.PersonId} does not exist.");
                }

                var bookingAlreadyExists =
                    await _context.Bookings.FirstOrDefaultAsync(
                        b => b.RoomId == newBooking.RoomId && b.DateFrom == newBooking.DateFrom);
                if (bookingAlreadyExists != null)
                {
                    return Results.Problem("A booking on the specified date and time already exists");
                }

                await _context.AddAsync(newBooking);
                await _context.SaveChangesAsync();
                return Results.Created($"/api/bookings/create/{newBooking.Id}", newBooking);
          
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
