using EnergyCompanyManager.Application;
using EnergyCompanyManager.Application.Queries;
using EnergyCompanyManager.Application.Services;
using EnergyCompanyManager.WebAPI.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.WebAPI.Test.Controllers;

public class EndpointControllerTest
{
    private readonly EndpointController _endpointController;
    private readonly IEndpointService _endpointService;
    private readonly IEndpointQuery _endpointQuery;

    public EndpointControllerTest()
    {
        _endpointService = Substitute.For<IEndpointService>();
        _endpointQuery = Substitute.For<IEndpointQuery>();
        _endpointController = new EndpointController(_endpointService, _endpointQuery);
    }

    [Fact]
    public void Create_ShouldCreateNewEndpoint()
    {
        var endpoint = new Endpoint("NSX1P2WX", 22, 0, "v0.0.2", 0);
        _endpointService.Create(endpoint).Returns(new Response<Endpoint?>(endpoint, true));

        var actionResult = _endpointController.Create(endpoint);
        var okResult = actionResult as OkObjectResult;
        var response = okResult!.Value as Response<Endpoint?>;

        response!.Data.Should().BeEquivalentTo(endpoint);
        response.Success.Should().BeTrue();
        response.ErrorMessage.Should().Be(null);
        _endpointService.Received().Create(endpoint);
    }

    [Fact]
    public void Create_ShouldNotCreateEndpointWithBadRequest()
    {
        var endpoint = new Endpoint("NSX1P2WX", 22, 0, "v0.0.2", 0);
        var errorMessage = "Bad request";
        _endpointService.Create(endpoint).Returns(new Response<Endpoint?>(endpoint, false, errorMessage));

        var actionResult = _endpointController.Create(endpoint);
        var badRequestResult = actionResult as BadRequestObjectResult;
        var response = badRequestResult!.Value as string;

        response.Should().Be(errorMessage);
        _endpointService.Received().Create(endpoint);
    }
}