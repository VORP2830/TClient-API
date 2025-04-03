using Clients.Domain.Interfaces;
using Clients.Infra.Data.Context;

namespace Clients.Infra.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IClientRepository _clientRepository;
    private IAddressRepository _addressRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IClientRepository ClientRepository
    {
        get
        {
            return _clientRepository ??= new ClientRepository(_context);
        }
    }

    public IAddressRepository AddressRepository
    {
        get
        {
            return _addressRepository ??= new AddressRepository(_context);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
