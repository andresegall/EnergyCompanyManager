using EnergyCompanyManager.Domain.Validators;
using EnergyCompanyManager.Infra.Repositories;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public class EndpointService : IEndpointService
{
    private readonly EndpointValidator _validator;

    public EndpointService()
    {
        _validator = new EndpointValidator();
    }

    public Response<Endpoint?> Create(Endpoint endpoint)
    {
        var propertiesValidation = ValidateEndpointProperties(endpoint);
        var existenceValidation = ValidateDuplicatedEndpoint(endpoint);

        if (!propertiesValidation.Success || !existenceValidation.Success)
        {
            var errorMessage = propertiesValidation.Message + existenceValidation.Message;
            return new Response<Endpoint?>(endpoint, false, errorMessage);
        }

        var entity = EndpointRepository.Create(endpoint);

        return new Response<Endpoint?>(entity, true);
    }

    public IEnumerable<Endpoint> GetAll()
    {
        return EndpointRepository.GetAll();
    }

    public Response<int> EditSwitchState(string serialNumber, int switchState)
    {
        var existenceValidation = ValidateEndpointExistence(serialNumber);
        var switchStateValidation = ValidateSwitchState(switchState);

        if (!existenceValidation.Success || !switchStateValidation.Success)
        {
            var errorMessage = existenceValidation.Message + switchStateValidation.Message;
            return new Response<int>(switchState, false, errorMessage);
        }

        var entity = EndpointRepository.GetBySerialNumber(serialNumber);

        entity!.SwitchState = switchState;

        return new Response<int>(switchState, true);
    }

    public Response Delete(string serialNumber)
    {
        var existenceValidation = ValidateEndpointExistence(serialNumber);

        if (!existenceValidation.Success)
        {
            return new Response(false, existenceValidation.Message);
        }

        EndpointRepository.Delete(serialNumber);

        return new Response(true);
    }

    public Endpoint? GetBySerialNumber(string serialNumber)
    {
        return EndpointRepository.GetBySerialNumber(serialNumber);
    }

    private (bool Success, string Message) ValidateEndpointProperties(Endpoint endpoint)
    {
        var validationResult = _validator.Validate(endpoint);

        if (!validationResult.IsValid)
        {
            var errorMessage = string.Empty;

            validationResult.Errors
                .ForEach(error => errorMessage += "Property " + error.PropertyName + " failed validation. Error was: " + error.ErrorMessage + "\n");

            return (Success: false, Message: errorMessage);
        }

        return (Success: true, Message: string.Empty);
    }

    private static (bool Success, string Message) ValidateDuplicatedEndpoint(Endpoint endpoint)
    {
        var entity = EndpointRepository.GetBySerialNumber(endpoint.SerialNumber);

        if (entity != null)
        {
            return (false, $"Serial number {endpoint.SerialNumber} already exists");
        }

        return (Success: true, Message: string.Empty);
    }

    private static (bool Success, string Message) ValidateSwitchState(int switchState)
    {
        if (switchState < 0 || switchState > 2)
        {
            return (Success: false, Message: "Invalid switch state");
        }

        return (Success: true, Message: string.Empty);
    }

    private static (bool Success, string Message) ValidateEndpointExistence(string serialNumber)
    {
        var entity = EndpointRepository.GetBySerialNumber(serialNumber);

        if (entity == null)
        {
            return (false, "Endpoint not found");
        }

        return (Success: true, Message: string.Empty);
    }
}
