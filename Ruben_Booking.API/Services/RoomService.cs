using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Services
{
    public class RoomService : IRoomService
    {
        private readonly RubenContext _context;

        public RoomService(RubenContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetAllRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            return rooms == null 
                ? Results.NotFound("No rooms found")
                : Results.Ok(rooms);
        }

        public async Task<IResult> GetRoomById(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

            return room == null
                ? Results.NotFound($"Room with id {id} was not found.")
                : Results.Ok(room);
        }
    }
}
