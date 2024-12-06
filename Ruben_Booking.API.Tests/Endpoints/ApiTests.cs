using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;
using Ruben_Booking.API.Database;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services;

namespace Ruben_Booking.API.Tests.Endpoints
{
    public class ApiTests
    {
        private readonly ITestOutputHelper _output;
        private readonly RubenContext _context;
        private readonly DbContextOptions<RubenContext> _options;
        private const string EMPLOYEE_EMAIL = "Hasse.Jansson@Snut.se";
        private const string CONSULTANT_EMAIL = "Janne.Claesson@Firman.se";
        private const int ID = 1;

        public ApiTests(ITestOutputHelper output)
        {
            _options = new DbContextOptionsBuilder<RubenContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RubenDB")
                .Options;
            _output = output;
            _context = new RubenContext(_options);
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
        public async Task GetAllRooms_ReturnsOk_WhenRoomsExist ()
        {
            const int AMOUNT_OF_ROOMS = 4;

            var roomService = new RoomService(_context);
            var result = await roomService.GetAllRooms();

            var okResult = Assert.IsType<Ok<List<Room>>>(result);
            var rooms = Assert.IsType<List<Room>>(okResult.Value);

            Assert.Equal(AMOUNT_OF_ROOMS, rooms.Count);
        }
        [Fact]
        public async Task GetRoomById_ReturnsOk_WhenRoomExists ()
        {
            var roomService = new RoomService(_context);
            var result = await roomService.GetRoomById(ID);

            var okResult = Assert.IsType<Ok<Room>>(result);
            var room = Assert.IsType<Room>(okResult.Value);

            Assert.Equal(ID, room.Id);
        }

    }
}