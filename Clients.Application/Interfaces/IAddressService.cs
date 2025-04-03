using Clients.Application.DTOs;

namespace Clients.Application.Interfaces;

public interface IAddressService
{
    Task<AddressDto> Create(long clientId, AddressDto address);
    Task<AddressDto> Update(AddressDto address);
    Task<AddressDto> Delete(long id);
}
