using Clients.Domain.Entities;
using Clients.Domain.Interfaces;
using Clients.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Clients.Infra.Data.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    private readonly ApplicationDbContext _context;
    public AddressRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Address?> GetById(long id)
    {
        return await _context.Addresses
                                .FirstOrDefaultAsync(s => s.Id == id);
    }
}
