using EnergyCompanyManager.Infra.Repositories;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public class EndpointService : IEndpointService
{
    public Endpoint? Create(Endpoint endpoint)
    {
        var entity = EndpointRepository.GetBySerialNumber(endpoint.SerialNumber);

        if (entity == null)
        {
            return EndpointRepository.Create(endpoint);
        }

        return null;
    }

    public IEnumerable<Endpoint> GetAll()
    {
        return EndpointRepository.GetAll();
    }

    public Endpoint? Edit(Endpoint endpoint)
    {
        var entity = EndpointRepository.GetBySerialNumber(endpoint.SerialNumber);

        if (entity != null)
        {
            entity.MeterModelId = endpoint.MeterModelId;
            entity.MeterNumber = endpoint.MeterNumber;
            entity.MeterFirmwareVersion = endpoint.MeterFirmwareVersion;
            entity.SwitchState = endpoint.SwitchState;
        }

        return entity;
    }

    public bool Delete(string serialNumber)
    {
        var entity = EndpointRepository.GetBySerialNumber(serialNumber);

        if (entity != null)
        {
            return EndpointRepository.Delete(entity);
        }

        return false;
    }

    public Endpoint? GetBySerialNumber(string serialNumber)
    {
        return EndpointRepository.GetBySerialNumber(serialNumber);
    }
}
