using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Services
{
    public class LoginService : ILoginService
    {
        private readonly RubenContext _context;

        public LoginService(RubenContext context)
        {
            _context = context;
        }
        public async Task<IResult> MatchLoginCredentials(string email, string password)
        {
            var consultant = await _context.Consultants
                .FirstOrDefaultAsync(c => c.Email == email && c.Password == password);

            if (consultant != null)
            {
                return Results.Ok(consultant);
            }
            
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email && e.Password == password);

            if (employee != null)
            {
                return Results.Ok(employee);
            }
            
            return Results.Unauthorized();
        }
    }
}
