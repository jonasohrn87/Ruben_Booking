using Ruben_Booking.API.Services;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, EmployeeService>();
            services.AddScoped<ConsultantService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                )
            );

            return services;
        }
        public static IServiceCollection AddDefaultServices(this IServiceCollection services) 
        {
            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddLogging();

            return services;
        }
    }
}
