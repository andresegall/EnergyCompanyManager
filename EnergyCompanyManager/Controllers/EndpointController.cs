using EnergyCompanyManager.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.WebAPI.Controllers;

[ApiController]
[Route("endpoint")]
public class EndpointController : ControllerBase
{
    private readonly IEndpointService _endpointService;

    public EndpointController(IEndpointService endpointService)
    {
        _endpointService = endpointService;
    }

    [HttpPost]
    public IActionResult Create(Endpoint endpoint)
    {
        var response = _endpointService.Create(endpoint);

        if (response == null)
        {
            return BadRequest();
        }

        return Ok(response);
    }

    [HttpPut]
    public IActionResult Edit(Endpoint endpoint)
    {
        var response = _endpointService.Edit(endpoint);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete]
    public IActionResult Delete(string serialNumber)
    {
        var success = _endpointService.Delete(serialNumber);

        if (success)
        {
            return Ok();
        }

        return BadRequest();
    }

    [HttpGet("get-all")]
    public IActionResult GetAll()
    {
        var response = _endpointService.GetAll();

        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetBySerialNumber(string serialNumber)
    {
        var response = _endpointService.GetBySerialNumber(serialNumber);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}