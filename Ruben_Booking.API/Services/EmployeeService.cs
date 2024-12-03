using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RubenContext _context;
        public EmployeeService(RubenContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null) 
            {
                return Results.NotFound($"No employee with id {id} was found.");
            }
            return Results.Ok(employee);
        }
    }
}
