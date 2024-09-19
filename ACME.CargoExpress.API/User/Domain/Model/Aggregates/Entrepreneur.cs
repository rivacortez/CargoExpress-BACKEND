using ACME.CargoExpress.API.Registration.Domain.Model.Aggregates;
using ACME.CargoExpress.API.User.Domain.Model.Commands;

namespace ACME.CargoExpress.API.User.Domain.Model.Aggregates;

public class Entrepreneur
{
    public Entrepreneur()
    {
        User = new IAM.Domain.Model.Aggregates.User();
    }
    
    public Entrepreneur(string name, string phone, string ruc, string address, string subscription, string logoImage, int userId, IAM.Domain.Model.Aggregates.User user)
    {
        Name = name;
        Phone = phone;
        Ruc = ruc;
        Address = address;
        Subscription = subscription;
        LogoImage = logoImage;
        UserId = userId;
        User = user;
    }
    
    public Entrepreneur(CreateEntrepreneurCommand command, IAM.Domain.Model.Aggregates.User user)
    {
        Name = command.Name;
        Phone = command.Phone;
        Ruc = command.Ruc;
        Address = command.Address;
        Subscription = command.Subscription;
        UserId = command.UserId;
        LogoImage = command.LogoImage;
        User = user;
    }
    
    public void Update(UpdateEntrepreneurCommand command)
    {
        Name = command.Name;
        Phone = command.Phone;
        Ruc = command.Ruc;
        Address = command.Address;
        Subscription = command.Subscription;
        LogoImage = command.LogoImage;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Ruc { get; set; } 
    public string Address { get; set; }
    public string Subscription { get; set; }
    public IAM.Domain.Model.Aggregates.User User { get; set; }
    public int UserId { get; set; }
    public string LogoImage { get; set; } 
    
    public ICollection<Trip> Trips { get; }
}