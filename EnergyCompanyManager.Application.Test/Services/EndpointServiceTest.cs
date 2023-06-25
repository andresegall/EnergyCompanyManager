using EnergyCompanyManager.Application.Services;
using EnergyCompanyManager.Domain.Validators;
using EnergyCompanyManager.Infra.Repositories;
using FluentAssertions;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Test.Services;

public class EndpointServiceTest
{
    private readonly EndpointService _endpointService;

    public EndpointServiceTest()
    {
        var validator = new EndpointValidator();
        _endpointService = new EndpointService(validator);
    }

    [Fact]
    public void Create_ShouldCreateNewEndpoint()
    {
        var endpoint = new Endpoint("NSX1P2WX", 22, 0, "v0.0.2", 0);

        var result = _endpointService.Create(endpoint);

        result.Data.Should().BeEquivalentTo(endpoint);
        result.Success.Should().BeTrue();
        result.ErrorMessage.Should().Be(null);
        EndpointRepository.GetBySerialNumber(endpoint.SerialNumber).Should().NotBeNull();
    }

    [Fact]
    public void Create_ShouldNotCreateDuplicatedEndpoint()
    {
        var endpoint = EndpointRepository.GetAll().First();

        var result = _endpointService.Create(endpoint);

        result.Data.Should().BeEquivalentTo(endpoint);
        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Be($"Serial number {endpoint.SerialNumber} already exists");
    }

    [Theory]
    [MemberData(nameof(InvalidParametersAndErrorMessages))]
    public void Create_ShouldNotCreateInvalidEndpoint(Endpoint endpoint, string errorMessage)
    {
        var result = _endpointService.Create(endpoint);

        result.Data.Should().BeEquivalentTo(endpoint);
        result.Success.Should().BeFalse();
        result.ErrorMessage.Should().Be(errorMessage);
        EndpointRepository.GetBySerialNumber(endpoint.SerialNumber).Should().BeNull();
    }

    public static IEnumerable<object[]> InvalidParametersAndErrorMessages()
    {
        yield return new object[]
        {
            new Endpoint("", 22, 0, "v0.0.2", 0),
            "Property SerialNumber failed validation. Error was: 'Serial Number' must not be empty.\n"
        };
        yield return new object[]
        {
            new Endpoint("NSX1P2WJ", 22, 0, "", 0),
            "Property MeterFirmwareVersion failed validation. Error was: 'Meter Firmware Version' must not be empty.\n"
        };
        yield return new object[]
        {
            new Endpoint("NSX1P2WJ", 22, 0, "v0.0.2", -1),
            "Property SwitchState failed validation. Error was: 'Switch State' must be greater than or equal to '0'.\n"
        };
        yield return new object[]
        {
            new Endpoint("NSX1P2WJ", 22, 0, "v0.0.2", 3),
            "Property SwitchState failed validation. Error was: 'Switch State' must be less than or equal to '2'.\n"
        };
    }
}