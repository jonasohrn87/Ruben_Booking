using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using Ruben_Booking.API.Database.Models;
using Ruben_Booking.API.Services.Interfaces;

namespace Ruben_Booking.API.Tests.Endpoints
{
    public class ApiTests
    {
        [Fact]
        public async Task GetUserById_ReturnsOk_WhenUserExists()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(s => s.GetEmployeeById(1))
                .ReturnsAsync(Results.Ok(new Employee { Id = 1, Email = "Hasse.Jansson@Snut.se" }));

            var handler = async (int id, IEmployeeService service) =>
            {
                return await service.GetEmployeeById(id);
            };

            // Act
            var result = await handler(1, mockService.Object);

            // Assert
            var okResult = Assert.IsType<Ok<Employee>>(result);
            var employee = Assert.IsType<Employee>(okResult.Value);

            Assert.Equal("Hasse.Jansson@Snut.se", employee.Email);
            Assert.Equal(1, employee.Id);
        }
    }
}