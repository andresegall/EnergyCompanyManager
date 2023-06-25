using EnergyCompanyManager.Application.Queries;
using EnergyCompanyManager.Infra.Repositories;
using FluentAssertions;

namespace EnergyCompanyManager.Application.Test.Queries;

public class EndpointQueryTest
{
    private readonly EndpointQuery _endpointQuery;

    public EndpointQueryTest()
    {
        _endpointQuery = new EndpointQuery();
    }

    [Fact]
    public void GetAll_ShouldReturnAllEndpoints()
    {
        var repositoryContent = EndpointRepository.GetAll();

        var result = _endpointQuery.GetAll();

        result.Should().BeEquivalentTo(repositoryContent);
    }

    [Fact]
    public void GetBySerialNumber_ShouldReturnCorrectEndpoint()
    {
        var endpoint = EndpointRepository.GetAll().First();

        var repositoryContent = EndpointRepository.GetBySerialNumber(endpoint.SerialNumber);

        var result = _endpointQuery.GetBySerialNumber(endpoint.SerialNumber);

        result.Should().BeEquivalentTo(repositoryContent);
    }
}