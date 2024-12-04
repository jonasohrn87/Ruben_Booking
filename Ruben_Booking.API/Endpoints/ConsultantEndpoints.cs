
using Ruben_Booking.API.Services;

namespace Ruben_Booking.API.Endpoints
{
    public static class ConsultantEndpoints
    {
        public static void MapConsultantEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/consultant/{id}", GetConsultantById);
        }

        private static async Task<IResult> GetConsultantById(ConsultantService consultantService, int id)
        {
            return await consultantService.GetUserById(id);
        }
    }
}
