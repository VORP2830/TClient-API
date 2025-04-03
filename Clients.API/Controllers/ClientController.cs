using Clients.Application.DTOs;
using Clients.Application.Interfaces;
using Clients.Domain.Filters;
using Clients.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Clients.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IAddressService _addressService;

    public ClientController(IClientService clientService, IAddressService addressService)
    {
        _addressService = addressService;
        _clientService = clientService;
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<ClientDto>> GetById(long id)
    {
        var client = await _clientService.GetById(id);
        return Ok(client);
    }

    [HttpGet]
    public async Task<ActionResult<PageList<ClientDto>>> Get([FromQuery] PageParams pageParams, [FromQuery] ClientFilter filter)
    {
        var result = await _clientService.Get(pageParams, filter);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create([FromBody] ClientDto clientDto)
    {
        var createdClient = await _clientService.Create(clientDto);
        return Ok(createdClient);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<ClientDto>> Update(long id, [FromBody] ClientDto clientDto)
    {
        clientDto.Id = id;
        var updatedClient = await _clientService.Update(clientDto);
        return Ok(updatedClient);
    }

    [HttpPost("{id:long}/address")]
    public async Task<ActionResult<AddressDto>> AddAddress(long id, [FromBody] AddressDto addressDto)
    {
        var createdAddress = await _addressService.Create(id, addressDto);
        return Ok(createdAddress);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<ClientDto>> Delete(long id)
    {
        var deletedClient = await _clientService.Delete(id);
        return Ok(deletedClient);
    }
}
