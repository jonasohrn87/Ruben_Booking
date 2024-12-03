using Ruben_Booking.API.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace Ruben_Booking.API.Endpoints
{
    public static class EmployeeEndpoints
    {
        public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/employee/{id}", GetEmployeeById);
        }

        static async Task<IResult> GetEmployeeById(IEmployeeService employeeService, int id)
        {
            return await employeeService.GetEmployeeById(id);
        }
    }
}
