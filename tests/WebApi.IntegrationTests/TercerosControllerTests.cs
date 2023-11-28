using System.Net;
using System.Text;
using Application.Handlers.Terceros;
using Application.Handlers.Terceros.Command.Create;
using Application.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApi.IntegrationTests.Configuration;
using Xunit;

namespace WebApi.IntegrationTests;

public class TercerosControllerTests : IntegrationTest
{
    [Fact]
    public async Task GetAll_WithNoTerceros_ReturnsEmptyList()
    {
        // Arrange
        var context = Scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var terceros = await context.Terceros.ToListAsync();
        context.Terceros.RemoveRange(terceros);
        await context.SaveChangesAsync(new CancellationToken());

        // Act
        var response = await TestHttpClient.GetAsync("/Siniestros");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        var tercerosList = JsonConvert.DeserializeObject<List<TerceroDto>>(content);
        tercerosList.Should().NotBeNull();
        tercerosList.Should().BeEmpty();
    }

    [Fact]
    public async Task Create_WithValidRequest_ReturnsCreatedTerceros()
    {
        // Arrange
        var createCommand = new CreateTercerosCommand
        {
            SiniestroId = Guid.Parse("96655240-3BD8-4D8C-8825-6FE9FB78E50D"),
            Nombre = "nombre",
            Apellido = "123",
            Dni = 123123,
            Tipo = 2
        };
        var jsonContent = new StringContent(JsonConvert.SerializeObject(createCommand), Encoding.UTF8, "application/json");

        // Act
        var response = await TestHttpClient.PostAsync("/Siniestros", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Create_WithInvalidRequest_ReturnsValidationError()
    {
        // Arrange
        var invalidCommand = new CreateTercerosCommand
        {
            SiniestroId = Guid.Parse("96655240-3BD8-4D8C-8825-6FE9FB78E51D"),
            Nombre = "nombre",
            Apellido = "123",
            Dni = 123123,
            Tipo = 2
        };
        var jsonContent = new StringContent(JsonConvert.SerializeObject(invalidCommand), Encoding.UTF8, "application/json");

        // Act
        var response = await TestHttpClient.PostAsync("/Siniestros", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Create_WithInvalidFutureDate_ReturnsBadRequest()
    {
        // Arrange
        var createCommand = new CreateTercerosCommand
        {
            SiniestroId = Guid.Parse("96655240-3BD8-4D8C-8825-6FE9FB78E51D"),
            Nombre = "nombre",
            Apellido = "123",
            Dni = 123123
        };
        var jsonContent = new StringContent(JsonConvert.SerializeObject(createCommand), Encoding.UTF8, "application/json");

        // Act
        var response = await TestHttpClient.PostAsync("/Siniestros", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}