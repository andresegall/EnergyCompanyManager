using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public interface IEndpointService
{
    public Endpoint Create(Endpoint endpoint);

    public List<Endpoint> GetAll();
}
