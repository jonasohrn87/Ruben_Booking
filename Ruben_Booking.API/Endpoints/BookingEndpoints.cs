
using Microsoft.AspNetCore.Mvc;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Endpoints
{
    public static class BookingEndpoints
    {
        public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/bookings", CreateBooking)
                .WithOpenApi()
                .WithDescription("Create a booking")
                .WithTags("Booking")
                .WithSummary("Endpoint to create a booking.");

            app.MapDelete("/api/bookings/{id}", DeleteBookingById)
                .WithOpenApi()
                .WithDescription("Delete booking by id")
                .WithTags("Booking")
                .WithDescription("Endpoint to delete the specific booking from the database.");

            app.MapGet("/api/bookings", GetAllBookings)
                .WithOpenApi()
                .WithDescription("Get all bookings")
                .WithTags("Booking")
                .WithDescription("Endpoint to get all bookings");

            app.MapGet("/api/bookings/{id}", GetBookingById)
                .WithOpenApi()
                .WithDescription("Get booking by id")
                .WithTags("Booking")
                .WithDescription("Endpoint to get booking by the specified id.");
        }

        private static async Task<IResult> CreateBooking(IBookingService service, [FromBody] Booking booking)
        {
            return await service.CreateBooking(booking);
        }
        private static async Task<IResult> DeleteBookingById(IBookingService service, int id)
        {
            return await service.DeleteBookingById(id);
        }
        private static async Task<IResult> GetAllBookings(IBookingService bookingService)
        {
            return await bookingService.GetAllBookings();
        }
        private static async Task<IResult> GetBookingById(IBookingService bookingService, int id)
        {
            return await bookingService.GetBookingById(id);
        }
    }
}
