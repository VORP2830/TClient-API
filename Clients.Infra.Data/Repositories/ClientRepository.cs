using Clients.Domain.Entities;
using Clients.Domain.Filters;
using Clients.Domain.Interfaces;
using Clients.Domain.Pagination;
using Clients.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Clients.Infra.Data.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    private readonly ApplicationDbContext _context;
    public ClientRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PageList<Client>> Get(PageParams pageParams, ClientFilter filter)
    {
        IQueryable<Client> query = _context.Clients;

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(c => c.Name.ToLower().Contains(filter.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(c => c.Email.ToLower().Contains(filter.Email.ToLower()));
        }

        var totalCount = await query.CountAsync();

        var items = await query.Skip((pageParams.PageNumber - 1) * pageParams.PageSize)
                            .Take(pageParams.PageSize)
                            .ToListAsync();

        return new PageList<Client>(items, totalCount, pageParams.PageNumber, pageParams.PageSize);
    }
    
    public async Task<Client?> GetById(long id)
    {
        return await _context.Clients
                                .Include(c => c.Addresses)
                                .FirstOrDefaultAsync(s => s.Id == id);
    }
}
