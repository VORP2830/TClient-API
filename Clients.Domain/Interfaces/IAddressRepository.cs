using Clients.Domain.Entities;

namespace Clients.Domain.Interfaces;

public interface IAddressRepository : IGenericRepository<Address>
{
    Task<Address?> GetById(long id);
}
