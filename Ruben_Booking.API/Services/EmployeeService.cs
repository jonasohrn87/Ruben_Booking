using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Ruben_Booking.API.Services
{
    public class EmployeeService : IUserService
    {
        private readonly RubenContext _context;
        public EmployeeService(RubenContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetUserById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return employee == null
                ? Results.NotFound($"No employee with id {id} was found")
                : Results.Ok(employee);
        }
    }
}
