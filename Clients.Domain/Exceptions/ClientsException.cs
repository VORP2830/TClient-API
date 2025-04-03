namespace Clients.Domain.Exceptions;

public class ClientsException : Exception
{
    public ClientsException(string error) : base(error) { }
    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new ClientsException(error);
        }
    }
}