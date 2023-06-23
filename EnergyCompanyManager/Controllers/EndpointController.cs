using EnergyCompanyManager.WebAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.WebAPI.Controllers;

[ApiController]
[Route("endpoint")]
public class EndpointController : ControllerBase
{
    public EndpointController()
    {
    }

    [HttpPost]
    public IActionResult CreateEndpoint(Endpoint endpoint)
    {
        if (EndpointPersistence.Endpoints.Any(x => x.SerialNumber == endpoint.SerialNumber))
        {
            return BadRequest();
        }

        EndpointPersistence.Endpoints.Add(endpoint);

        return Ok(endpoint);
    }

    [HttpPut]
    public IActionResult EditEndpoint(Endpoint endpoint)
    {
        var entity = EndpointPersistence.Endpoints.FirstOrDefault(x => x.SerialNumber == endpoint.SerialNumber);

        if (entity == null)
        {
            return NotFound();
        }

        entity.MeterModelId = endpoint.MeterModelId;
        entity.MeterNumber = endpoint.MeterNumber;
        entity.MeterFirmwareVersion = endpoint.MeterFirmwareVersion;
        entity.SwitchState = endpoint.SwitchState;

        return Ok(endpoint);
    }

    [HttpDelete]
    public IActionResult DeleteEndpoint(string serialNumber)
    {
        var entity = EndpointPersistence.Endpoints.FirstOrDefault(x => x.SerialNumber == serialNumber);

        if (entity == null)
        {
            return NotFound();
        }

        EndpointPersistence.Endpoints.Remove(entity);

        return Ok();
    }

    [HttpGet("get-all")]
    public IActionResult ListAllEndpoints()
    {
        return Ok(EndpointPersistence.Endpoints);
    }

    [HttpGet]
    public IActionResult FindEndpointBySerialNumber(string serialNumber)
    {
        var entity = EndpointPersistence.Endpoints.FirstOrDefault(x => x.SerialNumber == serialNumber);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }
}