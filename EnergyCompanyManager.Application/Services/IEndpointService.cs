﻿using Endpoint = EnergyCompanyManager.Domain.Models.Endpoint;

namespace EnergyCompanyManager.Application.Services;

public interface IEndpointService
{
    public Response<Endpoint?> Create(Endpoint endpoint);

    public Response<int> EditSwitchState(string serialNumber, int switchState);

    public Response Delete(string serialNumber);
}
