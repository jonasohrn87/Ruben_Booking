namespace Ruben_Booking.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");
        }
    }
}
