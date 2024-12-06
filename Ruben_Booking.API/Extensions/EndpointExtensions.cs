using Ruben_Booking.API.Endpoints;

namespace Ruben_Booking.API.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapApplicationEndpoints(this WebApplication app)
        {
            app.MapEmployeeEndpoints();
            app.MapConsultantEndpoints();
            app.MapLoginEndpoints();
            app.MapRoomEndpoints();
        }
    }
}
