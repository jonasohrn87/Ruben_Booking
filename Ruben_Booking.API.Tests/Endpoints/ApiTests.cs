﻿using Microsoft.AspNetCore.Http.HttpResults;
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

        public ApiTests(ITestOutputHelper output)
        {
            _options = new DbContextOptionsBuilder<RubenContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RubenDB")
                .Options;
            _output = output;
            _context = new RubenContext(_options);
        }
        [Fact]
        public async Task GetEmployeeById_ReturnsOk_WhenUserExists()
        {
            const string EMAIL = "Hasse.Jansson@Snut.se";
            const string PHONE_NUMBER = "0738239122";
            const int ID = 1;

            var employeeService = new EmployeeService(_context);

            var result = await employeeService.GetUserById(ID);

            var okResult = Assert.IsType<Ok<Employee>>(result);
            var employee = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal(EMAIL, employee.Email);
            Assert.Equal(ID, employee.Id);
            Assert.Equal(PHONE_NUMBER, employee.PhoneNumber);

            _output.WriteLine($"Input email: {EMAIL} response email: {employee.Email}");
        }
        [Fact]
        public async Task GetConsultantById_ReturnsOk_WhenUserExists()
        {
            const string EMAIL = "Janne.Claesson@Firman.se";
            const int ID = 1;

            var consultantService = new ConsultantService(_context);

            var result = await consultantService.GetUserById(ID);

            var okResult = Assert.IsType<Ok<Consultant>>(result);
            var consultant = Assert.IsType<Consultant>(okResult.Value);

            Assert.Equal(EMAIL, consultant.Email);
            Assert.Equal(ID, consultant.Id);

            _output.WriteLine($"Input email: {EMAIL} response email: {consultant.Email}");
        }

        [Fact]
        public async Task MatchEmployeeLoginCredentials_ReturnsOk_WhenMatched()
        {
            const string EMAIL = "Hasse.Jansson@Snut.se";
            const string PASSWORD = "wO9z6fREqcI0DubZUixB5VCeu01MUUQDYCXylmRbziM=";

            var loginService = new LoginService(_context);

            var result = await loginService.MatchLoginCredentials(EMAIL, PASSWORD);

            var okResult = Assert.IsType<Ok<Employee>>(result);
            var employee = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal(EMAIL, employee.Email);
            Assert.Equal(PASSWORD, employee.Password);
        }

        [Fact]
        public async Task MatchConsultantLoginCredentials_ReturnsOk_WhenMatched()
        {
            const string EMAIL = "Janne.Claesson@Firman.se";
            const string PASSWORD = "wx09ehRK2UGh3/5fJdPqmp9a/Y2DWx6cmoEkaKuU854=";

            var loginService = new LoginService(_context);

            var result = await loginService.MatchLoginCredentials(EMAIL, PASSWORD);

            var okResult = Assert.IsType<Ok<Consultant>>(result);
            var consultant = Assert.IsType<Consultant>(okResult.Value);

            Assert.Equal(EMAIL, consultant.Email);
            Assert.Equal(PASSWORD, consultant.Password);
        }

    }
}