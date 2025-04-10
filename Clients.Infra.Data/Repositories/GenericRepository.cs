using Clients.Domain.Interfaces;
using Clients.Infra.Data.Context;

namespace Clients.Infra.Data.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}