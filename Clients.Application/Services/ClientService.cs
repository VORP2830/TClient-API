using AutoMapper;
using Clients.Application.DTOs;
using Clients.Application.Interfaces;
using Clients.Domain.Entities;
using Clients.Domain.Filters;
using Clients.Domain.Interfaces;
using Clients.Domain.Pagination;

namespace Clients.Application.Services;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PageList<ClientDto>> Get(PageParams pageParams, ClientFilter filter)
    {
        PageList<Client> clients = await _unitOfWork.ClientRepository.Get(pageParams, filter);
        var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients.Items);
        return new PageList<ClientDto>(clientDtos.ToList(), clients.TotalCount, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<ClientDto> GetById(long id)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(id);
        if (client is null)
        {
            throw new KeyNotFoundException("Cliente não encontrado");
        }
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> Create(ClientDto client)
    {
        Client clientEntity = _mapper.Map<Client>(client);
        _unitOfWork.ClientRepository.Add(clientEntity);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(clientEntity);
    }

    public async Task<ClientDto> Delete(long id)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(id);
        if (client is null)
        {
            throw new KeyNotFoundException("Cliente não encontrado");
        }
        _unitOfWork.ClientRepository.Delete(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> Update(ClientDto model)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(model.Id);
        if (client is null)
        {
            throw new KeyNotFoundException("Cliente não encontrado");
        }
        _mapper.Map(model, client);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }
}
