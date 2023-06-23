using Microsoft.AspNetCore.Mvc;
using Endpoint = EnergyCompanyManager.Models.Endpoint;

namespace EnergyCompanyManager.Controllers;

[ApiController]
[Route("[controller]")]
public class EndpointController : ControllerBase
{
    public EndpointController()
    {
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Endpoint> Get()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new Endpoint("serialNumber", 0, 0, "meterFirmwareVersion", 0))
            .ToArray();
    }
}