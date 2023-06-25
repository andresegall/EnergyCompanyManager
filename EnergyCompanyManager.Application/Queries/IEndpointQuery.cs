using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Queries;

public interface IEndpointQuery
{
    public IEnumerable<Endpoint> GetAll();

    public Endpoint? GetBySerialNumber(string serialNumber);
}
