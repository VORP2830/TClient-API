using Clients.Application.DTOs;
using Clients.Domain.Filters;
using Clients.Domain.Pagination;

namespace Clients.Application.Interfaces;

public interface IClientService
{   
    Task<ClientDto> GetById(long id);
    Task<PageList<ClientDto>> Get(PageParams pageParams, ClientFilter filter);
    Task<ClientDto> Create(ClientDto client);
    Task<ClientDto> Update(ClientDto client);
    Task<ClientDto> Delete(long id);
}
