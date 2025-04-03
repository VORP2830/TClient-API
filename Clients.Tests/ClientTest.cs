using Clients.Domain.Entities;
using Clients.Domain.Exceptions;

namespace Clients.Tests;

public class ClientTest
{
    [Fact]
    public void Should_Create_Client_With_Valid_Name_And_Email()
    {
        var name = "Victor Osorio";
        var email = "victor@email.com";

        var client = new Client(name, email);

        Assert.Equal(name, client.Name);
        Assert.Equal(email, client.Email);
    }

    [Fact]
    public void Should_Throw_Exception_When_Name_Is_Empty()
    {
        var name = "";
        var email = "test@email.com";

        var ex = Assert.Throws<ClientsException>(() => new Client(name, email));
        Assert.Equal("Nome não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Name_Is_Not_Composed()
    {
        var name = "Victor";
        var email = "victor@email.com";

        var ex = Assert.Throws<ClientsException>(() => new Client(name, email));
        Assert.Equal("Nome deve ser composto (nome e sobrenome).", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Email_Is_Invalid()
    {
        var name = "Victor Osorio";
        var email = "victor-email.com";

        var ex = Assert.Throws<ClientsException>(() => new Client(name, email));
        Assert.Equal("Email deve conter '@' e '.'", ex.Message);
    }

    [Fact]
    public void Should_Add_Address_To_Client()
    {
        var client = new Client("Victor Osorio", "victor@email.com")
        {
            Addresses = new List<Address>()
        };

        var address = new Address("Rua 123", "123", "Centro", "Aracaju", "SE", "49000000", "Brasil");

        client.AddAddress(address);

        Assert.Single(client.Addresses);
        Assert.Contains(address, client.Addresses);
    }

    [Fact]
    public void Should_Throw_Exception_When_Email_Is_Empty()
    {
        var ex = Assert.Throws<ClientsException>(() => new Client("Victor Osorio", ""));
        Assert.Equal("Email não pode ser vazio.", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Email_Does_Not_Contain_At()
    {
        var ex = Assert.Throws<ClientsException>(() => new Client("Victor Osorio", "email.com"));
        Assert.Equal("Email deve conter '@' e '.'", ex.Message);
    }

    [Fact]
    public void Should_Throw_Exception_When_Email_Does_Not_Contain_Dot()
    {
        var ex = Assert.Throws<ClientsException>(() => new Client("Victor Osorio", "email@emailcom"));
        Assert.Equal("Email deve conter '@' e '.'", ex.Message);
    }

    [Fact]
    public void Should_Create_Client_Without_Addresses_Initially()
    {
        var client = new Client("Victor Osorio", "victor@email.com");
        Assert.Null(client.Addresses);
    }

    [Fact]
    public void Should_Add_Multiple_Addresses_To_Client()
    {
        var client = new Client("Victor Osorio", "victor@email.com")
        {
            Addresses = new List<Address>()
        };

        var address1 = new Address("Rua 1", "1", "Centro", "Aracaju", "SE", "49000000", "Brasil");
        var address2 = new Address("Rua 2", "2", "Bairro", "Aracaju", "SE", "49000001", "Brasil");

        client.AddAddress(address1);
        client.AddAddress(address2);

        Assert.Equal(2, client.Addresses.Count);
    }

}