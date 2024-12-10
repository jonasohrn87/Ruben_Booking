using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Ruben_Booking.API.Services.Interfaces;
using Ruben_Booking.API.Database.Models;


namespace Ruben_Booking.API.Endpoints
{
    public static class BoookingEndpoints
    {
        public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/bookings", GetAllBookings);
            app.MapGet("/api/bookings/{id}", GetBookingById);
            app.MapPost("/api/bookings", HandleBooking).WithName("CreateBooking");
        }
        private static async Task<IResult> GetAllBookings(IBookingService bookingService)
        {
            return await bookingService.GetAllBookings();
        }
        private static async Task<IResult> GetBookingById(IBookingService bookingService, int id)
        {
            return await bookingService.GetBookingById(id);
        }

        private static async Task<IResult> HandleBooking(IBookingService bookingService, [FromBody] Booking booking)
        {
            return await bookingService.CreateBooking(booking);
        }
    }
};
