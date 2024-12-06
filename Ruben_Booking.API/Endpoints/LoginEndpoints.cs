
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Endpoints
{
    public static class LoginEndpoints
    {
        public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/login", HandleLogin);
        }

        private static async Task<IResult> HandleLogin(ILoginService loginService, [FromBody] LoginRequest request)
        {
            // Matcha credentials från login service
            return await loginService.MatchLoginCredentials(request.Email, request.Password);
        }
    }
}
