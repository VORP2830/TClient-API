using Clients.Application.DTOs;
using Clients.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clients.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<AddressDto>> Delete(long id)
    {
        var deletedAddress = await _addressService.Delete(id);
        return Ok(deletedAddress);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<AddressDto>> Update(long id, [FromBody] AddressDto addressDto)
    {
        addressDto.Id = id;
        var updatedAddress = await _addressService.Update(addressDto);
        return Ok(updatedAddress);
    }
}
