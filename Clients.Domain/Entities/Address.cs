using Clients.Domain.Exceptions;

namespace Clients.Domain.Entities;

public class Address : BaseEntity
{
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Complement { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public string Country { get; private set; }
    public long ClientId { get; private set; }
    public Client Client { get; private set; }

    protected Address() { }

    public Address(
        string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string zipCode,
        string country,
        string complement = null)
    {
        Validate(street, neighborhood, city, state, zipCode, country);

        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
        Complement = complement;
    }

    private void Validate(string street, string neighborhood, string city, string state, string zipCode, string country)
    {
        ClientsException.When(string.IsNullOrWhiteSpace(street), "Logradouro não pode ser vazio.");
        ClientsException.When(string.IsNullOrWhiteSpace(neighborhood), "Bairro não pode ser vazio.");
        ClientsException.When(string.IsNullOrWhiteSpace(city), "Cidade não pode ser vazia.");
        ClientsException.When(string.IsNullOrWhiteSpace(state), "Estado não pode ser vazio.");
        ClientsException.When(string.IsNullOrWhiteSpace(zipCode), "CEP não pode ser vazio.");
        ClientsException.When(zipCode.Length != 8, "CEP deve ter 8 caracteres.");
        ClientsException.When(string.IsNullOrWhiteSpace(country), "País não pode ser vazio.");
    }
}
