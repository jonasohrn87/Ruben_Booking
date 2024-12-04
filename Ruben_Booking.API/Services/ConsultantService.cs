using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Services
{
    public class ConsultantService : IUserService
    {
        private readonly RubenContext _context;
        public ConsultantService(RubenContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetUserById(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);

            return consultant == null
                ? Results.NotFound($"No consultant with id {id} was found")
                : Results.Ok(consultant);
        }
    }
}
