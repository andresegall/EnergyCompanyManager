using EnergyCompanyManager.Application.Queries;
using EnergyCompanyManager.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.WebAPI.Controllers;

[ApiController]
[Route("endpoint")]
public class EndpointController : ControllerBase
{
    private readonly IEndpointService _endpointService;
    private readonly IEndpointQuery _endpointQuery;

    public EndpointController(IEndpointService endpointService, IEndpointQuery endpointQuery)
    {
        _endpointService = endpointService;
        _endpointQuery = endpointQuery;
    }

    [HttpPost]
    public IActionResult Create(Endpoint endpoint)
    {
        var response = _endpointService.Create(endpoint);

        if (!response.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return CreatedAtAction(
            nameof(GetBySerialNumber),
            new { serialNumber = endpoint.SerialNumber },
            response);
    }

    [HttpPatch]
    public IActionResult EditSwitchState(string serialNumber, int switchState)
    {
        var response = _endpointService.EditSwitchState(serialNumber, switchState);

        if (!response.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok(response);
    }

    [HttpDelete]
    public IActionResult Delete(string serialNumber)
    {
        var response = _endpointService.Delete(serialNumber);

        if (!response.Success)
        {
            return BadRequest(response.ErrorMessage);
        }

        return Ok();
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var response = _endpointQuery.GetAll();

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetBySerialNumber(string serialNumber)
    {
        var response = _endpointQuery.GetBySerialNumber(serialNumber);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}