namespace Clients.Application.DTOs;

public class ClientDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public IEnumerable<AddressDto> Addresses { get; set; }
}
