using Ruben_Booking.API.Database.Models;

namespace Ruben_Booking.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IResult> GetEmployeeById(int id);
    }
}
