namespace Ruben_Booking.API.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IResult> GetAllRooms();
        Task<IResult> GetRoomById(int id);
    }
}
