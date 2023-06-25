using EnergyCompanyManager.Infra.Repositories;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Queries;

public class EndpointQuery : IEndpointQuery
{
    public IEnumerable<Endpoint> GetAll()
    {
        return EndpointRepository.GetAll();
    }

    public Endpoint? GetBySerialNumber(string serialNumber)
    {
        return EndpointRepository.GetBySerialNumber(serialNumber);
    }
}
