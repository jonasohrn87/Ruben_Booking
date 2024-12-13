using Ruben_Booking.API.Database.Models;

namespace Ruben_Booking.API.Services.Interfaces
{
    public interface IUserService
    {
        Task<IResult> GetUserById(int id);
    }
}
