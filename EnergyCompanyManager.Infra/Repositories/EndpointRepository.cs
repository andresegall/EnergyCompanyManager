using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Infra.Repositories;

public static class EndpointRepository
{
    private static readonly List<Endpoint> _endpoints = new()
        {
            new Endpoint("NSX1P2W", 16, 0, "v0.0.1", 0),
            new Endpoint("NSX1P3W", 17, 0, "v0.0.1", 0),
            new Endpoint("NSX2P3W", 18, 0, "v0.0.1", 0),
            new Endpoint("NSX3P4W", 19, 0, "v0.0.1", 0)
        };

    public static Endpoint Create(Endpoint endpoint)
    {
        _endpoints.Add(endpoint);

        return endpoint;
    }

    public static IEnumerable<Endpoint> GetAll()
    {
        return _endpoints;
    }

    public static Endpoint? GetBySerialNumber(string serialNumber)
    {
        return _endpoints.Find(x => x.SerialNumber == serialNumber);
    }

    public static bool Delete(Endpoint endpoint)
    {
        return _endpoints.Remove(endpoint);
    }
}
