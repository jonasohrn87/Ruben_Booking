
using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Endpoints;
using Ruben_Booking.API.Services;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<RubenContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RubenDB"));

            builder.Services.AddScoped<IUserService, EmployeeService>();
            builder.Services.AddScoped<ConsultantService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
   

            builder.Services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                )
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.MapEmployeeEndpoints();
            app.MapConsultantEndpoints();
            app.MapLoginEndpoints();
            

            app.Run();
        }
    }
}
