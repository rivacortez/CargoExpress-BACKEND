﻿namespace ACME.CargoExpress.API.User.Domain.Model.Commands;

public record UpdateClientCommand(int ClientId, string Name, string Phone, string Ruc, string Address, string Subscription, int UserId);