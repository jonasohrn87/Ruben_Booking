
using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Extensions;

namespace Ruben_Booking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDefaultServices();
            builder.Services.AddDbContext<RubenContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            app.ConfigureMiddlewares();
            app.MapApplicationEndpoints();

            app.Run();
        }
    }
}
