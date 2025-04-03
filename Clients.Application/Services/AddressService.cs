using AutoMapper;
using Clients.Application.DTOs;
using Clients.Application.Interfaces;
using Clients.Domain.Entities;
using Clients.Domain.Interfaces;

namespace Clients.Application.Services;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public AddressService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AddressDto> Create(long clientId, AddressDto model)
    {
        Client client = await _unitOfWork.ClientRepository.GetById(clientId);
        if (client is null)
        {
            throw new KeyNotFoundException("Cliente não encontrado");
        }
        Address address = _mapper.Map<Address>(model);
        client.AddAddress(address);
        _unitOfWork.ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }

    public Task<AddressDto> Update(AddressDto address)
    {
        Address Address = _unitOfWork.AddressRepository.GetById(address.Id).Result;
        if (Address is null)
        {
            throw new KeyNotFoundException("Endereço não encontrado");
        }
        _mapper.Map(address, Address);
        _unitOfWork.AddressRepository.Update(Address);
        _unitOfWork.SaveChangesAsync();
        return Task.FromResult(_mapper.Map<AddressDto>(Address));
    }

    public async Task<AddressDto> Delete(long id)
    {
        Address address = await _unitOfWork.AddressRepository.GetById(id);
        if (address is null)
        {
            throw new KeyNotFoundException("Endereço não encontrado");
        }
        _unitOfWork.AddressRepository.Delete(address);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }
}
