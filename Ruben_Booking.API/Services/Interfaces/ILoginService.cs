namespace Ruben_Booking.API.Services.Interfaces
{
    public interface ILoginService
    {
        Task<IResult> MatchLoginCredentials(string email, string password);
    }
}
