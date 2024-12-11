using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.ErrorHandling;
using Ruben_Booking.API.Services;

namespace Ruben_Booking.API.Tests.Endpoints
{
    public class BookingServiceTests : IDisposable
    {
        private readonly RubenContext _context;
        private readonly ErrorHandler _errorHandler;
        private readonly DbContextOptions<RubenContext> _options;

        public BookingServiceTests()
        {
            _options = new DbContextOptionsBuilder<RubenContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB")
                .Options;
            _context = new RubenContext(_options);
            _errorHandler = new ErrorHandler();
            _context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _context.Bookings.RemoveRange(_context.Bookings);
            _context.SaveChanges();
        }

        //Booking tests
        [Fact]
        public async Task AddBooking_ShouldReturnCreated_WhenBookingCreated()
        {
            var newBooking = GenerateBookingObject();

            var bookingService = new BookingService(_context, _errorHandler);
            var result = await bookingService.CreateBooking(newBooking);

            var okResult = Assert.IsType<Created<EntityEntry<Booking>>>(result);
            var bookingEntry = Assert.IsType<EntityEntry<Booking>>(okResult.Value);

        }
        [Fact]
        public async Task DeleteBookingById_ShouldReturnOk_WhenBookingDeleted()
        {
            var newBooking = GenerateBookingObject();

            var bookingService = new BookingService(_context, _errorHandler);
            var createResult = await bookingService.CreateBooking(newBooking);
            var createdResult = Assert.IsType<Created<EntityEntry<Booking>>>(createResult);
            var bookingEntry = Assert.IsType<EntityEntry<Booking>>(createdResult.Value);

            int bookingId = bookingEntry.Entity.Id;

            var deleteResult = await bookingService.DeleteBookingById(bookingId);
            
            var okResult = Assert.IsType<Ok<Booking>>(deleteResult);
            var deletedBooking = Assert.IsType<Booking>(okResult.Value);
            Assert.Equal(bookingId, deletedBooking.Id);
        }

        public Booking GenerateBookingObject ()
        {
            DateTime dateFrom = new DateTime(2024, 12, 06, 12, 00, 00);
            DateTime dateTo = new DateTime(2024, 12, 06, 12, 30, 00);
            var booking = new Booking
            {
                RoomId = 1,
                PersonId = 1,
                DateFrom = dateFrom,
                DateTo = dateTo,
                Participants = new List<string> { "Janne", "Hasse" }
            };

            return booking;
        }
    }
}
