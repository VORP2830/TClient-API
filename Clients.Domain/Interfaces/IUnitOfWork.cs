namespace Clients.Domain.Interfaces;

public interface IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    IAddressRepository AddressRepository { get; }
    Task<bool> SaveChangesAsync();
}