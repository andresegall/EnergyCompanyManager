using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public interface IEndpointService
{
    public Endpoint? Create(Endpoint endpoint);

    public IEnumerable<Endpoint> GetAll();

    public Endpoint? Edit(Endpoint endpoint);

    public bool Delete(string serialNumber);

    public Endpoint? GetBySerialNumber(string serialNumber);
}
