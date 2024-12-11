using Microsoft.EntityFrameworkCore;

namespace Ruben_Booking.API.ErrorHandling
{
    public class ErrorHandler
    {
        public Dictionary<Exception,string> Errors { get; set; }

        public ErrorHandler()
        {
            Errors = new Dictionary<Exception, string>();
        }

        public async Task<IResult> Handle(Func<Task<IResult>> action)
        {
            try
            {
                return await action();
            }
            catch (DbUpdateException dbEx)
            {
                Errors.Add(dbEx, "Database operation failed");
                return Results.Problem("A database error occured.");
            }
            catch (ArgumentException argEx)
            {
                Errors.Add(argEx, "Invalid input provided.");
                return Results.BadRequest(argEx.Message);
            }
            catch (Exception ex)
            {
                Errors.Add(ex, "An unexpected error occurred.");
                return Results.Problem("An unexpected error occurred. Please try again later.", statusCode: 500);
            }
        }
    }
}
