﻿namespace ACME.CargoExpress.API.User.Interfaces.REST.Resources;

public record ClientResource(int Id, string Name, string Phone, string Ruc, string Address, string Subscription, int UserId);