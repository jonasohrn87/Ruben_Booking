
using Microsoft.AspNetCore.Mvc;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Endpoints
{
    public static class BookingEndpoints
    {
        public static void MapBookingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/booking/create", CreateBooking)
                .WithOpenApi()
                .WithDescription("Create a booking")
                .WithTags("Booking")
                .WithSummary("Endpoint to create a booking.");

            app.MapDelete("/api/booking/{id}", DeleteBookingById)
                .WithOpenApi()
                .WithDescription("Delete booking by id")
                .WithTags("Booking")
                .WithDescription("Endpoint to delete the specific booking from the database.");
        }

        private static async Task<IResult> CreateBooking(IBookingService service, [FromBody] Booking booking)
        {
            return await service.CreateBooking(booking);
        }
        private static async Task<IResult> DeleteBookingById(IBookingService service, int id)
        {
            return await service.DeleteBookingById(id);
        }
    }
}
