using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services;
using Ruben_Booking.API.Tests.Database;
using Ruben_Booking.API.ErrorHandling;

namespace Ruben_Booking.API.Tests.Endpoints
{
    public class ApiTests
    {
        private readonly ITestOutputHelper _output;
        private readonly TestCopyDbContext _context;
        private readonly ErrorHandler _errorHandler;
        private readonly DbContextOptions<RubenContext> _options;
        private const string EMPLOYEE_EMAIL = "Hasse.Jansson@Snut.se";
        private const string CONSULTANT_EMAIL = "Janne.Claesson@Firman.se";
        private const int ID = 1;
        private const int ROOM_ID = 1;
        private const int PERSON_ID = 1;
        private readonly DateTime testStartDate = new DateTime(2024, 12, 20, 0, 0, 0, DateTimeKind.Local);
        private readonly DateTime testEndDate = new DateTime(2024, 12, 20, 23, 59, 59, DateTimeKind.Local);

        public ApiTests(ITestOutputHelper output)
        {
            _options = new DbContextOptionsBuilder<RubenContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RubenDB_TestDB")
                .Options;
            _output = output;
            _context = new TestCopyDbContext(_options);
            _errorHandler = new ErrorHandler();
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
        // Employee tests
        [Fact]
        public async Task GetEmployeeById_ReturnsOk_WhenUserExists()
        {
            const string PHONE_NUMBER = "0738239122";

            var employeeService = new EmployeeService(_context);

            var result = await employeeService.GetUserById(ID);

            var okResult = Assert.IsType<Ok<Employee>>(result);
            var employee = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal(EMPLOYEE_EMAIL, employee.Email);
            Assert.Equal(ID, employee.Id);
            Assert.Equal(PHONE_NUMBER, employee.PhoneNumber);

            _output.WriteLine($"Input email: {EMPLOYEE_EMAIL} response email: {employee.Email}");
        }
        [Fact]
        public async Task MatchEmployeeLoginCredentials_ReturnsOk_WhenMatched()
        {
            const string PASSWORD = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=";

            var loginService = new LoginService(_context);

            var result = await loginService.MatchLoginCredentials(EMPLOYEE_EMAIL, PASSWORD);

            var okResult = Assert.IsType<Ok<Employee>>(result);
            var employee = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal(EMPLOYEE_EMAIL, employee.Email);
            Assert.Equal(PASSWORD, employee.Password);
        }

        // Consultant tests
        [Fact]
        public async Task GetConsultantById_ReturnsOk_WhenUserExists()
        {

            var consultantService = new ConsultantService(_context);

            var result = await consultantService.GetUserById(ID);

            var okResult = Assert.IsType<Ok<Consultant>>(result);
            var consultant = Assert.IsType<Consultant>(okResult.Value);

            Assert.Equal(CONSULTANT_EMAIL, consultant.Email);
            Assert.Equal(ID, consultant.Id);

            _output.WriteLine($"Input email: {CONSULTANT_EMAIL} response email: {consultant.Email}");
        }

        [Fact]
        public async Task MatchConsultantLoginCredentials_ReturnsOk_WhenMatched()
        {
            const string PASSWORD = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=";

            var loginService = new LoginService(_context);

            var result = await loginService.MatchLoginCredentials(CONSULTANT_EMAIL, PASSWORD);

            var okResult = Assert.IsType<Ok<Consultant>>(result);
            var consultant = Assert.IsType<Consultant>(okResult.Value);

            Assert.Equal(CONSULTANT_EMAIL, consultant.Email);
            Assert.Equal(PASSWORD, consultant.Password);
        }

        //Room tests
        [Fact]
        public async Task GetAllRooms_ReturnsOk_WhenRoomsExist()
        {
            const int AMOUNT_OF_ROOMS = 4;

            var roomService = new RoomService(_context);
            var result = await roomService.GetAllRooms();

            var okResult = Assert.IsType<Ok<List<Room>>>(result);
            var rooms = Assert.IsType<List<Room>>(okResult.Value);

            Assert.Equal(AMOUNT_OF_ROOMS, rooms.Count);
        }
        [Fact]
        public async Task GetRoomById_ReturnsOk_WhenRoomExists()
        {
            var roomService = new RoomService(_context);
            var result = await roomService.GetRoomById(ID);

            var okResult = Assert.IsType<Ok<Room>>(result);
            var room = Assert.IsType<Room>(okResult.Value);

            Assert.Equal(ID, room.Id);
        }

        [Fact]
        public async Task GetAllBookings_ReturnsOk_WhenNoBookingsExist()
        {
            var bookingService = new BookingService(_context, _errorHandler);
            var result = await bookingService.GetAllBookings();

            var okResult = Assert.IsType<Ok<List<Booking>>>(result);
            var bookings = Assert.IsType<List<Booking>>(okResult.Value);

            Assert.NotNull(bookings);
            if (bookings.Count == 0)
            {
                Assert.Empty(bookings);
                _output.WriteLine("No bookings found");
            }
            _output.WriteLine($"Amount of bookings: {bookings.Count}");
        }

        [Fact]
        public async Task GetAllBookings_ReturnsOk_WhenBookingsExist()
        {
            var bookingService = new BookingService(_context, _errorHandler);
            var result = await bookingService.GetAllBookings();
         
            var okResult = Assert.IsType<Ok<List<Booking>>>(result);
            var bookings = Assert.IsType<List<Booking>>(okResult.Value);

            Assert.NotNull(bookings);
            if (bookings.Count == 0)
            {

            Assert.NotEmpty(bookings);
            Assert.All(bookings, booking =>
            {
                Assert.NotEqual(0, booking.Id);
                Assert.NotEqual(0, booking.RoomId);
                Assert.NotEqual(0, booking.PersonId);
                Assert.True(booking.DateTo >= booking.DateFrom);
            });
            }
            _output.WriteLine($"Amount of bookings: {bookings.Count}");
        }

        [Fact]
        public async Task GetBookingById_ReturnsOk_WhenBookingExists()
        {
            var bookingService = new BookingService(_context, _errorHandler);

            var result = await bookingService.GetBookingById(ID);

            var okResult = Assert.IsType<Ok<Booking>>(result);
            var booking = Assert.IsType<Booking>(okResult.Value);

            Assert.Equal(ID, booking.Id);
            Assert.Equal(ROOM_ID, booking.RoomId);
            Assert.Equal(PERSON_ID, booking.PersonId);
            Assert.Equal(testStartDate, booking.DateFrom);
            Assert.Equal(testEndDate, booking.DateTo);
            Assert.True(booking.DateTo >= booking.DateFrom);
        }
    }
}