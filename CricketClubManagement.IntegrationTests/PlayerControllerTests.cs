//using CricketClubManagement.IntegrationTests;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace PlayerControllerTests
{
    public class PlayerControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public PlayerControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreatePlayer_WithValidData_Returns201()
        {
            // Arrange
            var roleResponse = await _client.PostAsJsonAsync("/api/roles", new { roleName = "Batsman" });
            var roleId = await roleResponse.Content.ReadFromJsonAsync<int>();

            var playerDto = new
            {
                playerName = "Virat Kohli",
                playerAge = 35,
                playerContact = "999-999-999",
                roleId
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/players", playerDto);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }


}