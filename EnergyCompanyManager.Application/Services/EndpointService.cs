using EnergyCompanyManager.Infra.Repositories;
using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public class EndpointService : IEndpointService
{
    public Endpoint Create(Endpoint endpoint)
    {
        return EndpointRepository.Create(endpoint);
    }

    public List<Endpoint> GetAll()
    {
        return EndpointRepository.GetAll();
    }
}
