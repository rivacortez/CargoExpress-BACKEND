﻿using ACME.CargoExpress.API.Registration.Domain.Model.Aggregates;
using ACME.CargoExpress.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoExpress.API.Registration.Interfaces.REST.Transform;

public static class TripResourceFromEntityAssembler
{
    public static TripResource ToResourceFromEntity(Trip entity)
    {
        return new TripResource(entity.Id, entity.Name, entity.CargoData, entity.TripData, entity.DriverId, entity.VehicleId, entity.ClientId, entity.EntrepreneurId);
    }
}