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
                new Employee {Id = 1, Email = "Hasse.Jansson@Snut.se", PhoneNumber = "0738239122", UserCredential = "EOESK20393", Password = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", Salt = new byte[16] },
                new Employee {Id = 2, Email = "Klas.Fransson@Snut.se", PhoneNumber = "0738115122", UserCredential = "EAOKE90113", Password = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", Salt = new byte[16] },
                new Employee {Id = 3, Email = "Ruben.Rubensson@Snut.se", PhoneNumber = "0728239622", UserCredential = "EKKLE10395", Password = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=", Salt = new byte[16] }
            );
            modelBuilder.Entity<Consultant>().HasData(
                new Consultant { Id = 1, Email = "Janne.Claesson@Firman.se", UserCredential = "CSKED18372", Password = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", Salt = new byte[16]  },
                new Consultant { Id = 2, Email = "Jöns.Jönsson@Firman.se", UserCredential = "CSAPD18372", Password = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", Salt = new byte[16] },
                new Consultant { Id = 3, Email = "Martin.Beck@Firman.se", UserCredential = "CSKAE18372", Password = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=", Salt = new byte[16] }
            );
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "Sommarängen", HasProjector = true, HasWhiteBoard = true, IsInService = true, MaxSeats = 8, Description = "Konferensrum 1" },
                new Room { Id = 2, Name = "Höstvinden", HasProjector = true, HasWhiteBoard = false, IsInService = true, MaxSeats = 4, Description = "Konferensrum 2" },
                new Room { Id = 3, Name = "Vinterstugan", HasProjector = false, HasWhiteBoard = true, IsInService = true, MaxSeats = 6, Description = "Konferensrum 3" },
                new Room { Id = 4, Name = "Vårsolen", HasProjector = true, HasWhiteBoard = true, IsInService = false, MaxSeats = 6, Description = "Konferensrum 4" }
            );
        }
    }
}
