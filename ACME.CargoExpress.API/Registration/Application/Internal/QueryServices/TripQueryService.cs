﻿using ACME.CargoExpress.API.Registration.Domain.Model.Aggregates;
using ACME.CargoExpress.API.Registration.Domain.Model.Entities;
using ACME.CargoExpress.API.Registration.Domain.Model.Queries;
using ACME.CargoExpress.API.Registration.Domain.Repositories;
using ACME.CargoExpress.API.Registration.Domain.Services;
using ACME.CargoExpress.API.User.Domain.Model.Aggregates;
using ACME.CargoExpress.API.User.Domain.Model.Queries;

namespace ACME.CargoExpress.API.Registration.Application.Internal.QueryServices;

public class TripQueryService(ITripRepository tripRepository, IEvidenceRepository evidenceRepository, IAlertRepository alertRepository, IOngoingTripRepository ongoingTripRepository, IExpenseRepository expenseRepository)
    : ITripQueryService
{
    public async Task<Trip?> Handle(GetTripByIdQuery query)
    {
        return await tripRepository.FindByIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<Trip>> Handle(GetAllTripsQuery query)
    {
        return await tripRepository.ListAsync();
    }
    public async Task<Evidence?> Handle(GetEvidencesByTripIdQuery query)
    {
        return await evidenceRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<Expense?> Handle(GetExpensesByTripIdQuery query)
    {
        return await expenseRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<Alert>> Handle(GetAlertsByTripIdQuery query)
    { 
        return await alertRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<OngoingTrip?> Handle(GetOngGoingTripByIdQuery query)
    { 
        return await ongoingTripRepository.FindByTripIdAsync(query.TripId);
    }
    public async Task<IEnumerable<Driver>> Handle(GetDriversByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindDriversByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindVehiclesByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    
    public async Task<IEnumerable<Trip>> Handle(GetTripsByClientIdQuery query)
    {
        return await tripRepository.FindByClientIdAsync(query.ClientId);
    }
    
    public async Task<IEnumerable<Trip>> Handle(GetTripsByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    
    public async Task<IEnumerable<Client>> Handle(GetClientsByEntrepreneurId query)
    {
        return await tripRepository.FindClientsByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    
    
}

