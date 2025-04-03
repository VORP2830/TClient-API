using Clients.Domain.Entities;
using Clients.Domain.Exceptions;

namespace Clients.Tests;

public class AddressTest
{
    [Fact]
    public void Should_Create_Address_With_Valid_Data()
    {
        var street = "Rua Principal";
        var number = "123";
        var neighborhood = "Centro";
        var city = "Aracaju";
        var state = "SE";
        var zipCode = "49000000";
        var country = "Brasil";
        var complement = "Apto 101";

        var address = new Address(street, number, neighborhood, city, state, zipCode, country, complement);

        Assert.Equal(street, address.Street);
        Assert.Equal(number, address.Number);
        Assert.Equal(neighborhood, address.Neighborhood);
        Assert.Equal(city, address.City);
        Assert.Equal(state, address.State);
        Assert.Equal(zipCode, address.ZipCode);
        Assert.Equal(country, address.Country);
        Assert.Equal(complement, address.Complement);
    }

    [Fact]
    public void Should_Throw_Exception_When_Street_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("", "123", "Centro", "Aracaju", "SE", "49000000", "Brasil"));
        Assert.Equal("Logradouro não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_ZipCode_Is_Invalid_Length()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("Rua A", "123", "Centro", "Aracaju", "SE", "4900", "Brasil"));
        Assert.Equal("CEP deve ter 8 caracteres.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Neighborhood_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("Rua B", "123", "", "Aracaju", "SE", "49000000", "Brasil"));
        Assert.Equal("Bairro não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Country_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("Rua B", "123", "Centro", "Aracaju", "SE", "49000000", ""));
        Assert.Equal("País não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Allow_Empty_Complement()
    {
        var address = new Address("Rua A", "123", "Centro", "Aracaju", "SE", "49000000", "Brasil");
        Assert.Null(address.Complement);
    }

    [Fact]
    public void Should_Throw_Exception_When_City_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("Rua A", "123", "Centro", "", "SE", "49000000", "Brasil"));
        Assert.Equal("Cidade não pode ser vazia.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_State_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() =>
            new Address("Rua A", "123", "Centro", "Aracaju", "", "49000000", "Brasil"));
        Assert.Equal("Estado não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Create_Address_With_Null_Client()
    {
        var address = new Address("Rua A", "123", "Centro", "Aracaju", "SE", "49000000", "Brasil");
        Assert.Null(address.Client);
    }

    [Fact]
    public void Should_Allow_Numeric_Street_Number()
    {
        var address = new Address("Rua A", "456", "Centro", "Aracaju", "SE", "49000000", "Brasil");
        Assert.Equal("456", address.Number);
    }

}
