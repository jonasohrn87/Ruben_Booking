
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Endpoints
{
    public static class RoomEndpoints
    {
        public static void MapRoomEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/rooms", GetAllRooms);

            app.MapGet("/api/rooms/{id}", GetRoomById);
        }

        private static async Task<IResult> GetAllRooms(IRoomService roomService)
        {
            return await roomService.GetAllRooms();
        }

        private static async Task<IResult> GetRoomById(IRoomService roomService, int id)
        {
            return await roomService.GetRoomById(id);
        }
    }
}
