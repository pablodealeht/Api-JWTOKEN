using System.Net;
using System.Text;
using Application.Handlers.Siniestros.Commands.Create;
using Application.Handlers.Siniestros.Queries;
using Application.Handlers.Terceros.Command.Create;
using Application.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApi.IntegrationTests.Configuration;
using Xunit;

namespace WebApi.IntegrationTests;

public class SiniestrosControllerTests : IntegrationTest
{
    [Fact]
    public async Task GetAll_WithNoSiniestros_ReturnsEmptyList()
    {
        // Arrange
        var context = Scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        var siniestros = await context.Siniestros.ToListAsync();
        context.Siniestros.RemoveRange(siniestros);
        await context.SaveChangesAsync(new CancellationToken());

        // Act
        var response = await TestHttpClient.GetAsync("/Siniestros");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        
        var content = await response.Content.ReadAsStringAsync();
        var siniestrosList = JsonConvert.DeserializeObject<List<SiniestroDto>>(content);
        siniestrosList.Should().NotBeNull();
        siniestrosList.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAll_With5Siniestros_Return5Siniestros()
    {
        // Arrange
        // Act
        var response = await TestHttpClient.GetAsync("/Siniestros");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await response.Content.ReadAsStringAsync();
        var siniestros = JsonConvert.DeserializeObject<List<SiniestroDto>>(content);

        siniestros.Should().HaveCount(5);
    }

    [Fact]
    public async Task Create_WithValidRequest_ReturnsCreated()
    {
        // Arrange
        var createCommand = new CreateSiniestroCommand
        {
            Descripcion = "Test",
            Fecha = DateTime.Now,
            Direccion = "Test",
            Localidad = "Test",
            Pais = "Test",
            Provincia = "Test"
        };
        var jsonContent = new StringContent(JsonConvert.SerializeObject(createCommand), Encoding.UTF8, "application/json");

        // Act
        var response = await TestHttpClient.PostAsync("/Siniestros", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    [Fact]
    public async Task Create_WithValidRequest_ReturnsCreatedTerceros()
    {
        // Arrange
        var createCommand = new CreateTercerosCommand
        {
            SiniestroId = Guid.Parse("96655240-3BD8-4D8C-8825-6FE9FB78E50D"),
            Nombre = "nombre",
            Apellido= "123",
            Dni= 123123,
            Tipo= 2
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
        var invalidCommand = new CreateSiniestroCommand
        {
            Descripcion = "Test",
            Fecha = DateTime.Now,
            Direccion = "Test",
            Localidad = "Test",
            Tipo = TipoSiniestroDto.Choque,
            Pais = "Test",
            Provincia = "Test"
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
        var createCommand = new CreateSiniestroCommand
        {
            Descripcion = "Test",
            Fecha = DateTime.Now.AddHours(1),  // fecha futura
            Direccion = "Test",
            Localidad = "Test",
            Tipo = TipoSiniestroDto.Robo,
            Pais = "Test",
            Provincia = "Test"
        };
        var jsonContent = new StringContent(JsonConvert.SerializeObject(createCommand), Encoding.UTF8, "application/json");

        // Act
        var response = await TestHttpClient.PostAsync("/Siniestros", jsonContent);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

}