using Clients.Domain.Exceptions;

namespace Clients.Domain.Entities;

public class Client : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public List<Address> Addresses { get; set; }

    protected Client() { }

    public Client(string name, string email)
    {
        Validate(name, email);

        Name = name;
        Email = email;
    }

    private void Validate(string name, string email)
    {
        ClientsException.When(string.IsNullOrWhiteSpace(name), "Nome não pode ser vazio.");

        var parts = name.Trim().Split(' ');
        ClientsException.When(parts.Length < 2, "Nome deve ser composto (nome e sobrenome).");

        ClientsException.When(string.IsNullOrWhiteSpace(email), "Email não pode ser vazio.");
        ClientsException.When(!email.Contains("@") || !email.Contains("."), "Email deve conter '@' e '.'");
    }

    public void AddAddress(Address address)
    {
        Addresses.Add(address);
    }
}
