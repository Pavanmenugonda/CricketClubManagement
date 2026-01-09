using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace RoleControllerTests
{
    public class RoleControllerTests : IClassFixture<CustomWebApplicationFactory>
   {
    private readonly HttpClient _client;

    public RoleControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateRole_WithValidData_Returns201()
    {
        // Arrange
        var roleDto = new
        {
            roleName = "Bowler"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/roles", roleDto);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        // Optionally: verify returned content
        var createdRole = await response.Content.ReadFromJsonAsync<dynamic>();
        Assert.NotNull(createdRole);
        Assert.Equal("Bowler", (string)createdRole.roleName);
    }

    [Fact]
    public async Task CreateRole_WithDuplicateName_Returns400()
    {
        // Arrange
        var roleDto = new
        {
            roleName = "All-Rounder"
        };

        // Act
        var firstResponse = await _client.PostAsJsonAsync("/api/roles", roleDto);
        var secondResponse = await _client.PostAsJsonAsync("/api/roles", roleDto);

        // Assert
        Assert.Equal(HttpStatusCode.Created, firstResponse.StatusCode);
        Assert.Equal(HttpStatusCode.BadRequest, secondResponse.StatusCode);
    }
  }
}
