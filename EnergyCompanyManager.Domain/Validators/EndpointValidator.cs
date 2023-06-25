using FluentValidation;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Domain.Validators;

public class EndpointValidator : AbstractValidator<Endpoint>
{
    public EndpointValidator()
    {
        RuleFor(endpoint => endpoint.SerialNumber)
            .NotNull()
            .NotEmpty();

        RuleFor(endpoint => endpoint.MeterFirmwareVersion)
           .NotNull()
           .NotEmpty();

        RuleFor(endpoint => endpoint.SwitchState)
           .GreaterThanOrEqualTo(0)
           .LessThanOrEqualTo(2);
    }
}
