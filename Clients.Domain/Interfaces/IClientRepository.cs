using Clients.Domain.Entities;
using Clients.Domain.Filters;
using Clients.Domain.Pagination;

namespace Clients.Domain.Interfaces;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<PageList<Client>> Get(PageParams pageParams, ClientFilter filter);
    Task<Client?> GetById(long id);
}
