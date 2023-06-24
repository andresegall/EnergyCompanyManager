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

    public static List<Endpoint> GetAll()
    {
        return _endpoints;
    }
}
