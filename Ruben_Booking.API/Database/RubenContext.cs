using Microsoft.EntityFrameworkCore;
using Ruben_Booking.API.Database.Models;

namespace Ruben_Booking.API.Database
{
    public class RubenContext : DbContext
    {
        public RubenContext(DbContextOptions option) : base(option) 
        { 
        }
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee {Id = 1, Email = "Hasse.Jansson@Snut.se", PhoneNumber = "0738239122", UserCredential = "EOESK20193", Password = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", Salt = "0xC0EF73E9F444A9C2340EE6D9522C41E5" }
            );
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant { Id = 1, Email = "Janne.Claesson@Firman.se", UserCredential = "CSKED18372", Password = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", Salt = "0xC31D3D7A144AD941A1DFFE5F25D3EA9A" }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Sommarängen", HasProjector = true, HasWhiteBoard = true, IsInService = true, MaxSeats = 8, Description = "Längst ner i korridoren till höger om den vänstra dörren." }
            );
        }
    }
}
