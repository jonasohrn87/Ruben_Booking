
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Endpoints
{
    public static class LoginEndpoints
    {
        public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/login", HandleLogin);
        }

        private static async Task<IResult> HandleLogin(ILoginService loginService, string email, string password)
        {
            return await loginService.MatchLoginCredentials(email, password);
        }
    }
}
